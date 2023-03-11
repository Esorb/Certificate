using Esorb.Certificate.App.Model.Interfaces;
using Esorb.Certificate.App.Model;
using System.ComponentModel.Design;

namespace Esorb.Certificate.App.Model.ValueInputs;

public class NumberOfHoursInput : PersistentObject, IValueInput
{
    private long numberOfHoursID;
    private string inputContextID = string.Empty;
    private string numberOfHoursName;
    private int numberOfHours;
    private InputContext? context;


    public NumberOfHoursInput()
    {
        numberOfHoursName = "";
    }
    public long NumberOfHoursID
    {
        get
        {
            return numberOfHoursID;
        }
        set
        {
            numberOfHoursID = value;
        }
    }

    public string InputContextID
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
            return numberOfHoursName;
        }
        set
        {
            numberOfHoursName = value;
        }
    }

    public string ValueString
    {
        get
        {
            return numberOfHours.ToString();
        }
        set
        {
            if (int.TryParse(value, out numberOfHours))
            {
                if (numberOfHours < 0)
                {
                    numberOfHours = 0;
                }
            }
            else
            {
                numberOfHours = 0;
            }
        }
    }

    public InputContext? Context
    {
        get
        {
            return context;
        }
        set
        {
            context = value;
        }
    }
}
