using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esorb.Certificate.App.Model;
using Esorb.Certificate.App.Database;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Esorb.Certificate.App.ViewModel
{
    public class CertifcateViewModel : ObservableObject, ICertifcateViewModel
    {
        private ICertificateSettingsViewModel certificateSettingsViewModel = new CertificateSettingsViewModel();
        private ICertificateDataViewModel certificateDateViewModel;
        private TeachersViewModel teachers;
        private IList<PupilViewModel> pupilsViewModel;
        private IList<CertificateTemplateViewModel> certificateTemplatesViewModel;
        private IList<GradeLimitViewModel> gradeLimitsViewModel;
        private CertificateModel certificateModel;

        public CertifcateViewModel(CertificateModel certificateModel)
        {
            this.certificateModel = certificateModel;
            teachers = new(this.certificateModel);
            BuildCertificateViewModelFromCertificateModel();

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
            certificateDateViewModel = new CertificateDataViewModel(certificateModel.CertificateData, certificateModel.DbHelper);
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

        public ICertificateSettingsViewModel CertificateSettingsViewModel
        {
            get => certificateSettingsViewModel;
            set { certificateSettingsViewModel = value; }
        }

        public ICertificateDataViewModel CertificateDateViewModel
        {
            get => certificateDateViewModel;
            set { certificateDateViewModel = value; }
        }

        public IList<GradeLimitViewModel> GradeLimitsViewModel
        {
            get => gradeLimitsViewModel;
            set { gradeLimitsViewModel = value; }
        }
    }
}
