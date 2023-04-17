using Esorb.Certificate.App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esorb.Certificate.App.Model.Enumerables;

namespace Esorb.Certificate.App.Model;

public class Subject : PersistentObject
{

    public string SubjectName { get; set; } = string.Empty;
    public Evaluation Evaluation { get; set; }
    public bool HasPartialSubjects { get; set; }
    public bool CalculateGrade { get; set; }
    public int PositionOnPage { get; set; }
    public bool HasComment { get; set; } = true;
    public int MaxNumberOfCommentLines { get; set; } = 4;
    public string CertificateTemplateId { get; set; } = string.Empty;
    public string CertificateTemplatePageId { get; set; } = string.Empty;
    public CertificateTemplate? CertificateTemplate { get; set; }
    public CertificateTemplatePage? CertificateTemplatePage { get; set; }
    public IList<PartialSubject> PartialSubjects { get; private set; } = new List<PartialSubject>();
    public IList<Rating> Ratings { get; private set; } = new List<Rating>();
    public IList<Subject> ContainingSubjects { get; set; } = new List<Subject>();
}
