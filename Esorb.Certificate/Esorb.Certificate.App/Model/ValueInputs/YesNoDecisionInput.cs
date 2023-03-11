using Esorb.Certificate.App.Model.Interfaces;
using Esorb.Certificate.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.Model.ValueInputs;

public class YesNoDecisionInput : PersistentObject, IValueInput
{
    private long yesNoDecisionID;
    private long inputContextID;
    private string yesNoDecisionName;
    private bool yesNoDecisionValue;
    private InputContext? context;

    public YesNoDecisionInput()
    {
        yesNoDecisionName = string.Empty;
    }

    public long YesNoDecisionID
    {
        get
        {
            return yesNoDecisionID;
        }
        set
        {
            yesNoDecisionID = value;
        }
    }

    public long InputContextID
    {
        get
        {
            return inputContextID;
        }
        set
        {
            inputContextID = value;
        }
    }

    public string ValueName
    {
        get
        {
            return yesNoDecisionName;
        }
        set
        {
            yesNoDecisionName = value;
        }
    }

    public string ValueString
    {
        get
        {
            if (yesNoDecisionValue)
            {
                return "Ja";
            }
            else
            {
                return "Nein";
            }
        }
        set
        {
            yesNoDecisionValue = (value == "ja" || value == "Ja" || value == "JA" || value == "j" || value == "J");
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

    InputContext? IValueInput.Context { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
