using Esorb.Certificate.App.Model.ValueInputs;

namespace Esorb.Certificate.App.Model.Interfaces;

public interface IValueInput
{
    string ValueName { get; set; }
    string ValueString { get; set; }
    InputContext? Context { get; set; }
}