namespace Esorb.Certificate.App.Model;

public class Rating : PersistentObject
{
    public string Text { get; set; }
    public string SubjectId { get; set; }
    public Subject Subject { get; set; }
}