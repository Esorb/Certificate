using System;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esorb.Certificate.App.Model;
using Esorb.Certificate.App.Database;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace Esorb.Certificate.App.ViewModel
{
    public class CertifcateViewModel : ObservableObject
    {
        private readonly CertificateModel certificateModel;
        private readonly DbHelper dbHelper;

        #region Constructor
        public CertifcateViewModel(CertificateModel certificateModel)
        {
            CertificateSettingsViewModel = new CertificateSettingsViewModel();
            this.certificateModel = certificateModel;
            dbHelper = certificateModel.DbHelper;

            BuildRelayCommands();
            BuildCertificateViewModelFromCertificateModel();
        }

        #endregion

        #region Partial Viewmodels
        public GradeLevelLegendsViewModell GradeLevelLegendsViewModell { get; set; }
        public GradeLimitsViewModel GradeLimitsViewModel { get; set; }
        public TeachersViewModel TeachersViewModel { get; set; }
        public CertificateSettingsViewModel CertificateSettingsViewModel { get; set; }
        public CertificateDataViewModel CertificateDataViewModel { get; set; }
        public CertificateTemplatesViewModel CertificateTemplatesViewModel { get; set; }
        public SchoolClassesViewModel SchoolClassesViewModel { get; set; }
        public SubjectsViewModel SubjectsViewModel { get; set; }

        #endregion

        #region RelayCommands and Functions
        public RelayCommand SelectCertificateFile { get; private set; }
        public RelayCommand SelectOutputFolder { get; private set; }

        public void HandleTeacherChange()
        {
            CertificateSettingsViewModel.Teacher = SelectedTeacher.FullName;
            CertificateSettingsViewModel.TeacherGUID = SelectedTeacher.ID;
        }

        public void HandleSchoolClassChange()
        {
            CertificateSettingsViewModel.SchoolClass = SelectedSchoolClass.ClassName;
            CertificateSettingsViewModel.SchoolClassGUID = SelectedSchoolClass.ID;
        }

        #endregion

        #region Selected ocjects
        public TeacherViewModel SelectedTeacher { get; set; }
        public SchoolClassViewModel SelectedSchoolClass { get; set; }

        private void SetSelectedTeacher()
        {
            var numberOfTeachers = TeachersViewModel?.Teachers?.Count ?? 0;
            if (numberOfTeachers == 0) { return; }
            if (CertificateSettingsViewModel == null) { return; }
            if (string.IsNullOrEmpty(CertificateSettingsViewModel.TeacherGUID)) { return; }
            if (!TeachersViewModel!.Teachers.Any(t => t.ID == CertificateSettingsViewModel.TeacherGUID)) { return; }

            SelectedTeacher = TeachersViewModel.Teachers.FirstOrDefault(t => t.ID == CertificateSettingsViewModel.TeacherGUID)!;
        }

        private void SetSelectedSchoolClass()
        {
            var numberOfSchoolClasses = SchoolClassesViewModel.SchoolClasses?.Count ?? 0;
            if (numberOfSchoolClasses == 0) { return; }
            if (CertificateSettingsViewModel == null) { return; }
            if (string.IsNullOrEmpty(CertificateSettingsViewModel.SchoolClassGUID)) { return; }
            if (!SchoolClassesViewModel!.SchoolClasses.Any(sc => sc.ID == CertificateSettingsViewModel.SchoolClassGUID)) { return; }

            SelectedSchoolClass = SchoolClassesViewModel.SchoolClasses.FirstOrDefault(sc => sc.ID == CertificateSettingsViewModel.SchoolClassGUID)!;
        }
        #endregion

        #region Private ViewModel Builders
        private void BuildRelayCommands()
        {
            SelectCertificateFile = new RelayCommand(ExecuteSelectCertificateFile, CanExecuteSelectCertificateFile);
            SelectOutputFolder = new RelayCommand(ExecuteSelectOutputFolder, CanExecuteSelectOutputFolder);
        }

        private void BuildCertificateViewModelFromCertificateModel()
        {
            BuildPartialViewModels();
            SetSelectedTeacher();
            SetSelectedSchoolClass();
        }

        private void BuildPartialViewModels()
        {
            TeachersViewModel = new(this.certificateModel);
            CertificateTemplatesViewModel = new(certificateModel);
            GradeLevelLegendsViewModell = new(certificateModel);
            GradeLimitsViewModel = new(certificateModel);
            SchoolClassesViewModel = new(certificateModel);
            CertificateDataViewModel = new(certificateModel);
            SubjectsViewModel = new(certificateModel);
        }

        #endregion

        #region Private parts of RelayCommands
        private void ExecuteSelectCertificateFile()
        {
            Microsoft.Win32.OpenFileDialog ofd = new()
            {
                Filter = "Zeugnisbasisdateien (*.db)|*.db",
                Multiselect = false,
                Title = "Zeugnisbasisdatei öffnen"
            };
            var result = ofd.ShowDialog();
            if (result is not null && result is true)
            {
                string databasePath = ofd.FileName;
                HandleCertificateFileChanged(databasePath);
            }
        }

        private void HandleCertificateFileChanged(string databasePath)
        {
            if (string.IsNullOrWhiteSpace(databasePath))
            {
                MessageBox.Show("Sie haben keine Datei ausgewählt!");
                return;
            }
            if (!dbHelper.IsCertificateFile(databasePath))
            {
                MessageBox.Show("Die Ausgewählte Datei ist keine valide Zeugnisbasisdatei!");
                return;
            }
            if (databasePath.Contains("OneDrive") || databasePath.Contains("Dropbox"))
            {
                string webProvider;
                if (databasePath.Contains("OneDrive")) { webProvider = "OneDrive"; }
                else { webProvider = "Dropbox"; }
                MessageBox.Show($"Bitte verschieben Sie die Zeugnisbasisdatei ein lokales Verzeichnis und wählen Sie die Datei dann noch einmal aus! Das Verzeichnis, in dem sich die Datei gegenwärtig befindet, wird im Internet auf {webProvider} gespiegelt.", "Datenschutz-Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CertificateSettingsViewModel.DatabasePath = databasePath;
        }

        private bool CanExecuteSelectCertificateFile()
        {
            return true;
        }

        private void ExecuteSelectOutputFolder()
        {
            FolderBrowserDialog folderBrowserDialog = new()
            {
                SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };
            folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var result = folderBrowserDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string OutputFolder = folderBrowserDialog.SelectedPath;
                HandleOutputFolderChanged(OutputFolder);
            }
        }
        private void HandleOutputFolderChanged(string outputFolder)
        {
            if (string.IsNullOrWhiteSpace(outputFolder))
            {
                MessageBox.Show("Sie haben kein Ausgabeverzeichnis ausgewählt!");
                return;
            }
            if (!Directory.Exists(outputFolder))
            {
                MessageBox.Show("Das gewählte Verzeichnis existiert nicht!");
                return;
            }
            if (outputFolder.Contains("OneDrive") || outputFolder.Contains("Dropbox"))
            {
                string webProvider;
                if (outputFolder.Contains("OneDrive")) { webProvider = "OneDrive"; }
                else { webProvider = "Dropbox"; }
                MessageBox.Show($"Bitte wählen Sie aus Datenschutzgründen ein lokales Verzeichnis! Das Verzeichnis, dass Sie gewählt haben, wird im Internet auf {webProvider} gespiegelt.", "Datenschutz-Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CertificateSettingsViewModel.OutputFolder = outputFolder;
        }

        private bool CanExecuteSelectOutputFolder()
        {
            return true;
        }

        #endregion
    }
}
