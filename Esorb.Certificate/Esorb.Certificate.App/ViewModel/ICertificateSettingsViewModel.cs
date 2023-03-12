namespace Esorb.Certificate.App.ViewModel
{
    public interface ICertificateSettingsViewModel
    {
        string DatabasePath { get; set; }
        string HalfYear { get; set; }
        string SchoolClass { get; set; }
        string SchoolYear { get; set; }
        string Teacher { get; set; }
    }
}