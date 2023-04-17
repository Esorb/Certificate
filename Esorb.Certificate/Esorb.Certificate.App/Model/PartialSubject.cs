using Esorb.Certificate.App.Model.Enumerables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.Model;

public class PartialSubject : PersistentObject
{
    public string PartialSubjectName { get; set; } = string.Empty;
    public Evaluation Evaluation { get; set; }
    public bool CalculateGrade { get; set; }
    public string SubjectID { get; set; } = string.Empty;
    public Subject? Subject { get; set; }
    public CertificateTemplate? CertificateTemplate { get; set; }
    public IList<Rating> Ratings { get; private set; } = new List<Rating>();

}
