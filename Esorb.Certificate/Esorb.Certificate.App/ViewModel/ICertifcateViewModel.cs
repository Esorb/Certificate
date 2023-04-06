using System.Collections.Generic;

namespace Esorb.Certificate.App.ViewModel
{
    public interface ICertifcateViewModel
    {
        CertificateDataViewModel CertificateDateViewModel { get; set; }
        ICertificateSettingsViewModel CertificateSettingsViewModel { get; set; }
        CertificateTemplatesViewModel CertificateTemplatesViewModel { get; }
        GradeLevelLegendsViewModell GradeLevelLegendsViewModell { get; set; }
        IList<GradeLimitViewModel> GradeLimitsViewModel { get; set; }
        IList<PupilViewModel> PupilsViewModel { get; }
        SchoolClassesViewModel SchoolClassesViewModel { get; set; }
        TeachersViewModel Teachers { get; }
    }
}