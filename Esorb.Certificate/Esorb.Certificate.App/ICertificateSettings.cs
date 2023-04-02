namespace Esorb.Certificate.App
{
    public interface ICertificateSettings
    {
        string DatabasePath { get; set; }
        string HalfYear { get; set; }
        string OutPutFolder { get; set; }
        string Page { get; set; }
        string SchoolClass { get; set; }
        string SchoolYear { get; set; }
        string SubPage { get; set; }
        string Teacher { get; set; }
        string MenuPosition { get; set; }

        void Save();
    }
}