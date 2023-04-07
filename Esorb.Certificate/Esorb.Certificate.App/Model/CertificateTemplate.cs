using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.Model;

public class CertificateTemplate : PersistentObject
{
    public int Yearlevel { get; set; }
    public int HalfYear { get; set; }
    public bool IsFullYearReport { get; set; }
    public IList<CertificatePage> CertificatePages { get; private set; } = new List<CertificatePage>();
}
