using Esorb.Certificate.App.Model.Interfaces;
using Esorb.Certificate.App.Model;

namespace Esorb.Certificate.App.Model.ValueInputs;

public class CommentInput : IValueInput
{
    public CommentInput()
    {
    }

    public string InputContextID { get; set; } = string.Empty;
    public string ValueName { get; set; } = string.Empty;
    public string ValueString { get; set; } = string.Empty;
    public int MaxLength { get; set; }
    public InputContext? Context { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
}
