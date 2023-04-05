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
        private ICertificateDataViewModel certificateDataViewModel;
        private TeachersViewModel teachers;
        private CertificateTemplatesViewModel certificateTemplatesViewModel;
        private GradeLevelLegendsViewModell gradeLevelLegendsViewModell;
        private SchoolClassesViewModel schoolClassesViewModel;

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

        public ICertificateSettingsViewModel CertificateSettingsViewModel
        {
            get => certificateSettingsViewModel;
            set { certificateSettingsViewModel = value; }
        }

        public ICertificateDataViewModel CertificateDateViewModel
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
    }
}
