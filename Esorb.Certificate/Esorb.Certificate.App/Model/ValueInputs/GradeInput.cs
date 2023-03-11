using Esorb.Certificate.App.Model.Interfaces;

namespace Esorb.Certificate.App.Model.ValueInputs;

public class GradeInput : IValueInput
{
    private string gradeInputValue = string.Empty;
    public GradeInput()
    {
    }

    public long GradeInputID { get; set; }
    public string InputContextID { get; set; } = string.Empty;
    public string ValueName { get; set; } = string.Empty;
    public string ValueString
    {
        get
        {
            return gradeInputValue;
        }
        set
        {
            gradeInputValue = value switch
            {
                "1" => "sehr gut",
                "sehr gut" => "sehr gut",
                "2" => "gut",
                "gut" => "gut",
                "3" => "befriedigend",
                "befriedigend" => "befriedigend",
                "4" => "ausreichend",
                "ausreichend" => "ausreichend",
                "5" => "mangelhaft",
                "mangelhaft" => "mangelhaft",
                "6" => "ungenügend",
                "ungenügend" => "ungenügend",
                _ => "falsche Eingabe"
            };
        }
    }
    public InputContext? Context { get; set; }
}
