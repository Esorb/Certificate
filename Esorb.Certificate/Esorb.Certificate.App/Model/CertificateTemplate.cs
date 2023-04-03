using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.Model;

public class CertificateTemplate : PersistentObject, ICertificateTemplate
{
    public int Yearlevel { get; set; }
    public int HalfYear { get; set; }
}
