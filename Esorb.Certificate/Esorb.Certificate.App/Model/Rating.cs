namespace Esorb.Certificate.App.Model;

public class Rating : PersistentObject
{
    public string Text { get; set; }
    public string SubjectId { get; set; } = string.Empty;
    public Subject? Subject { get; set; }
    public string PartialSubjectId { get; set; } = string.Empty;
    public PartialSubject? PartialSubject { get; set; }
}