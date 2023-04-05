using CommunityToolkit.Mvvm.Input;

namespace Esorb.Certificate.App.ViewModel
{
    public interface ICertificateTemplatesViewModel
    {
        RelayCommand AddCertificateTemplate { get; }
        RelayCommand RemoveCertificateTemplate { get; }
        CertificateTemplateViewModel SelectedCertificateTemplate { get; set; }
    }
}