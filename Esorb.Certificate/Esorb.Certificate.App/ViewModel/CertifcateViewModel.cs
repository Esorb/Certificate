using System;
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
        private CertificateModel certificateModel;
        private DbHelper dbHelper;

        #region Constructor
        public CertifcateViewModel(CertificateModel certificateModel)
        {
            CertificateSettingsViewModel = new CertificateSettingsViewModel();
            this.certificateModel = certificateModel;
            dbHelper = certificateModel.DbHelper;

            BuildCertificateViewModelFromCertificateModel();

        }

        #endregion

        #region Partial Viewmodels
        public GradeLevelLegendsViewModell GradeLevelLegendsViewModell { get; set; }
        public TeachersViewModel Teachers { get; set; }
        public CertificateSettingsViewModel CertificateSettingsViewModel { get; set; }
        public CertificateDataViewModel CertificateDataViewModel { get; set; }
        public CertificateTemplatesViewModel CertificateTemplatesViewModel { get; set; }
        public SchoolClassesViewModel SchoolClassesViewModel { get; set; }

        #endregion

        #region RelayCommands
        public RelayCommand SelectCertificateFile { get; private set; }
        public RelayCommand SelectOutputFolder { get; private set; }

        #endregion

        #region Selected ocjects
        public Teacher SelectedTeacher { get; set; }
        public SchoolClass SelectedSchoolClass { get; set; }

        #endregion

        #region Private ViewModel Builders
        private void BuildRelayCommands()
        {
            SelectCertificateFile = new RelayCommand(ExecuteSelectCertificateFile, CanExecuteSelectCertificateFile);
            SelectOutputFolder = new RelayCommand(ExecuteSelectOutputFolder, CanExecuteSelectOutputFolder);
        }

        private void BuildCertificateViewModelFromCertificateModel()
        {
            Teachers = new(this.certificateModel);
            CertificateTemplatesViewModel = new(certificateModel);
            GradeLevelLegendsViewModell = new(certificateModel);
            SchoolClassesViewModel = new(certificateModel);
            CertificateDataViewModel = new(certificateModel);

            BuildGradeLimitsViewModel();
        }

        private void BuildGradeLimitsViewModel()
        {
            GradeLimitsViewModel = new List<GradeLimitViewModel>();

            foreach (var gl in certificateModel.GradeLimits)
            {
                GradeLimitsViewModel.Add(new GradeLimitViewModel(gl, certificateModel.DbHelper));
            }

            GradeLimitsViewModel = GradeLimitsViewModel.OrderBy(glvm => glvm.GradeNumeric).ToList();
        }

        //private void BuildCertificateDataViewModel()
        //{
        //}

        #endregion

        private void GetSelectedTeacher()
        {

        }
        public IList<PupilViewModel> PupilsViewModel { get; set; }
        public IList<GradeLimitViewModel> GradeLimitsViewModel { get; set; }

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
                System.Windows.MessageBox.Show(databasePath);
            }
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
            //folderBrowserDialog.SelectedPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "OneDrive", "Documents");
            var result = folderBrowserDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string path = folderBrowserDialog.SelectedPath;
                System.Windows.MessageBox.Show(path);
            }
        }
        private bool CanExecuteSelectOutputFolder()
        {
            return true;
        }

        #endregion
    }
}
