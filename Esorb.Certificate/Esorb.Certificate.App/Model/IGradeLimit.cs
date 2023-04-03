namespace Esorb.Certificate.App.Model
{
    public interface IGradeLimit
    {
        string Grade { get; set; }
        int GradeNumeric { get; set; }
        double PercentageLimit { get; set; }
    }
}