using System.Collections.Generic;

namespace Esorb.Certificate.App.Model
{
    public interface ICertificateTemplate
    {
        IList<CertificatePage> CertificatePages { get; }
        int HalfYear { get; set; }
        bool IsFullYearReport { get; set; }
        int Yearlevel { get; set; }
    }
}