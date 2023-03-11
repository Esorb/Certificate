using Esorb.Certificate.App.Model.Interfaces;
using Esorb.Certificate.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.Model.ValueInputs;

public class RatingInput : PersistentObject, IValueInput
{
    private string ratingInputValue = string.Empty;
    private InputContext? context;

    public string InputContextID { get; set; } = string.Empty;
    public string ValueName { get; set; } = string.Empty;
    public string ValueString
    {
        get => ratingInputValue;
        set
        {
            ratingInputValue = value switch
            {
                "4" => "****",
                "****" => "****",
                "3" => "***",
                "***" => "***",
                "2" => "**",
                "**" => "**",
                "1" => "*",
                "*" => "*",
                _ => "falsche Eingabe"
            };
        }
    }

    public InputContext? Context
    {
        get => context;
        set
        {
            context = value;
        }
    }

}
