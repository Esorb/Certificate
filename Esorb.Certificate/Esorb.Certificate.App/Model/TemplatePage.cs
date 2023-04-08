using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.Model
{
    public class TemplatePage : PersistentObject
    {
        public int PageNumber { get; set; }
        public string CertificateTemplateId { get; set; }
        public CertificateTemplate CertificateTemplate { get; set; }
    }
}
