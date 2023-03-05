using Esorb.Certificate.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.Model
{
    public class CertificateData : PersistentObject
    {

        public string SchoolYear { get; set; } = string.Empty;
        public short HalfYear { get; set; }
        public DateTime DateOfSchoolConference { get; set; }
        public DateTime DateOfCertificateDistribution { get; set; }
        public DateTime DateOfRestartLessons { get; set; }
        public DateTime TimeOfRestartLessons { get; set; }
        public string CertificateTemplateID { get; set; } = string.Empty;
        public CertificateTemplate? Template { get; set; }
    }
}
