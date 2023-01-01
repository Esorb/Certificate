using Esorb.Certificate.Model.ValueInputs;

namespace Esorb.Certificate.Model.Interfaces
{
    public interface IValueInput
    {
        string ValueName { get; set; }
        string ValueString { get; set; }
        InputContext? Context { get; set; }
    }
}