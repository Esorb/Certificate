using Microsoft.EntityFrameworkCore.Metadata;

namespace Esorb.Certificate.Model.Interfaces
{
    public interface IValueInput
    {
        long PupilID { get; set; }
        long CertificateID { get; set; }
        long ContentID { get; set; }
        string ValueName { get; set; }
        string ValueString { get; set; }

    }
}