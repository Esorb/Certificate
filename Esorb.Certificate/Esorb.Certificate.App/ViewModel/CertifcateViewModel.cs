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
        public RelayCommand SelectCertificateFile { get; private set; }
        public RelayCommand SelectOutputFolder { get; private set; }
        public GradeLevelLegendsViewModell GradeLevelLegendsViewModell { get; set; }

        private IList<PupilViewModel> pupilsViewModel;
        private IList<GradeLimitViewModel> gradeLimitsViewModel;

        private CertificateModel certificateModel;

        public CertifcateViewModel(CertificateModel certificateModel)
        {
            this.certificateModel = certificateModel;
            CertificateSettingsViewModel = new CertificateSettingsViewModel();
            Teachers = new(this.certificateModel);
            CertificateTemplatesViewModel = new(this.certificateModel);
            GradeLevelLegendsViewModell = new(this.certificateModel);
            SchoolClassesViewModel = new(this.certificateModel);

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
            this.CertificateDateViewModel = new CertificateDataViewModel(certificateModel.CertificateData, certificateModel.DbHelper);
        }


        public IList<PupilViewModel> PupilsViewModel
        {
            get => pupilsViewModel;
        }

        public TeachersViewModel Teachers { get; set; }
        public CertificateSettingsViewModel CertificateSettingsViewModel { get; set; }
        public CertificateDataViewModel CertificateDateViewModel { get; set; }
        public CertificateTemplatesViewModel CertificateTemplatesViewModel { get; set; }
        public SchoolClassesViewModel SchoolClassesViewModel { get; set; }
        public IList<GradeLimitViewModel> GradeLimitsViewModel
        {
            get => gradeLimitsViewModel;
            set { gradeLimitsViewModel = value; }
        }

        public Teacher SelectedTeacher { get; set; }
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
