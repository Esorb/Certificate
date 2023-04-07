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
        private CertificateSettingsViewModel certificateSettingsViewModel = new CertificateSettingsViewModel();
        private CertificateDataViewModel certificateDataViewModel;
        private TeachersViewModel teachers;
        private CertificateTemplatesViewModel certificateTemplatesViewModel;
        private GradeLevelLegendsViewModell gradeLevelLegendsViewModell;
        private SchoolClassesViewModel schoolClassesViewModel;

        public RelayCommand SelectCertificateFile { get; private set; }
        public RelayCommand SelectOutputFolder { get; private set; }
        public GradeLevelLegendsViewModell GradeLevelLegendsViewModell
        {
            get { return gradeLevelLegendsViewModell; }
            set { gradeLevelLegendsViewModell = value; }
        }

        private IList<PupilViewModel> pupilsViewModel;
        private IList<GradeLimitViewModel> gradeLimitsViewModel;
        private CertificateModel certificateModel;

        public CertifcateViewModel(CertificateModel certificateModel)
        {
            this.certificateModel = certificateModel;

            teachers = new(this.certificateModel);
            certificateTemplatesViewModel = new(this.certificateModel);
            gradeLevelLegendsViewModell = new(this.certificateModel);
            schoolClassesViewModel = new(this.certificateModel);

            BuildCertificateViewModelFromCertificateModel();
            SelectCertificateFile = new RelayCommand(ExecuteSelectCertificateFile, CanExecuteSelectCertificateFile);
            SelectOutputFolder = new RelayCommand(ExecuteSelectOutputFolder, CanExecuteSelectOutputFolder);
        }

        private void BuildCertificateViewModelFromCertificateModel()
        {
            BuildCertificateDataViewModel();
            BuildGradeLimitsViewModel();
        }

        private void BuildGradeLimitsViewModel()
        {
            gradeLimitsViewModel = new List<GradeLimitViewModel>();

            foreach (var gl in certificateModel.GradeLimits)
            {
                gradeLimitsViewModel.Add(new GradeLimitViewModel(gl, certificateModel.DbHelper));
            }

            gradeLimitsViewModel = gradeLimitsViewModel.OrderBy(glvm => glvm.GradeNumeric).ToList();
        }
        private void BuildCertificateDataViewModel()
        {
            certificateDataViewModel = new CertificateDataViewModel(certificateModel.CertificateData, certificateModel.DbHelper);
        }


        public IList<PupilViewModel> PupilsViewModel
        {
            get => pupilsViewModel;
        }

        public TeachersViewModel Teachers
        {
            get => teachers;
            private set { teachers = value; }
        }

        public CertificateSettingsViewModel CertificateSettingsViewModel
        {
            get => certificateSettingsViewModel;
            set { certificateSettingsViewModel = value; }
        }

        public CertificateDataViewModel CertificateDateViewModel
        {
            get => certificateDataViewModel;
            set { certificateDataViewModel = value; }
        }

        public CertificateTemplatesViewModel CertificateTemplatesViewModel
        {
            get => certificateTemplatesViewModel;
            private set { certificateTemplatesViewModel = value; }
        }

        public SchoolClassesViewModel SchoolClassesViewModel
        {
            get => schoolClassesViewModel;
            set { schoolClassesViewModel = value; }
        }

        public IList<GradeLimitViewModel> GradeLimitsViewModel
        {
            get => gradeLimitsViewModel;
            set { gradeLimitsViewModel = value; }
        }

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
    }
}
