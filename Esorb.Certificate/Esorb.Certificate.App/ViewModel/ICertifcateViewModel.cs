using System.Collections.Generic;

namespace Esorb.Certificate.App.ViewModel
{
    public interface ICertifcateViewModel
    {
        ICertificateDataViewModel CertificateDateViewModel { get; set; }
        ICertificateSettingsViewModel CertificateSettingsViewModel { get; set; }
        CertificateTemplatesViewModel CertificateTemplatesViewModel { get; }
        public SchoolClassesViewModel SchoolClassesViewModel { get; set; }
        IList<GradeLimitViewModel> GradeLimitsViewModel { get; set; }
        IList<PupilViewModel> PupilsViewModel { get; }
        TeachersViewModel Teachers { get; }
    }
}