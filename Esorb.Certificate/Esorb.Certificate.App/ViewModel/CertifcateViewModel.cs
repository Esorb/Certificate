using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esorb.Certificate.App.Model;
using Esorb.Certificate.App.Database;

namespace Esorb.Certificate.App.ViewModel
{
    public class CertifcateViewModel : ObservableObject, ICertifcateViewModel
    {
        private ICertificateSettingsViewModel certificateSettingsViewModel = new CertificateSettingsViewModel();
        private ICertificateDataViewModel certificateDateViewModel;
        private IList<TeacherViewModel> teachersViewModel;
        private IList<PupilViewModel> pupilsViewModel;
        private IList<CertificateTemplateViewModel> certificateTemplatesViewModel;
        private IList<GradeLimitViewModel> gradeLimitsViewModel;
        private CertificateModel certificateModel;

        public CertifcateViewModel(CertificateModel certificateModel)
        {
            this.certificateModel = certificateModel;
            BuildCertificateViewModelFromCertificateModel();
        }

        private void BuildCertificateViewModelFromCertificateModel()
        {
            BuildCertificateDataViewModel();
            BuildTeacherViewModel();
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

        private void BuildTeacherViewModel()
        {
            teachersViewModel = new List<TeacherViewModel>();

            foreach (var t in certificateModel.Teachers)
            {
                teachersViewModel.Add(new TeacherViewModel(t));
            }

            teachersViewModel = teachersViewModel.OrderBy(tvm => tvm.FullName).ToList();
        }

        public IList<PupilViewModel> PupilsViewModel
        {
            get => pupilsViewModel;
            set { pupilsViewModel = value; }
        }


        public IList<TeacherViewModel> TeachersViewModel
        {
            get => teachersViewModel;
            set { teachersViewModel = value; }
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
