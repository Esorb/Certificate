using Esorb.Certificate.App.Basics;
using Esorb.Certificate.App.Model.Interfaces;
using Esorb.Certificate.App.Model;
using System.ComponentModel.Design;

namespace Esorb.Certificate.App.Model.ValueInputs;

public class NumberOfHoursInput : ViewModelBase, IValueInput
{
    private long numberOfHoursID;
    private long inputContextID;
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
            OnPropertyChanged(nameof(NumberOfHoursID));
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
            OnPropertyChanged(nameof(InputContextID));
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
            OnPropertyChanged(nameof(ValueName));
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
            OnPropertyChanged(nameof(ValueString));
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
            OnPropertyChanged(nameof(Context));
        }
    }
}
