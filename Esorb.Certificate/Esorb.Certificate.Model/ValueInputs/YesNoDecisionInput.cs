using Esorb.Certificate.Basics;
using Esorb.Certificate.Model.Interfaces;
using Esorb.Certificate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.Model.ValueInputs
{
    public class YesNoDecisionInput : ViewModelBase, IValueInput
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
                OnPropertyChanged(nameof(YesNoDecisionID));
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
                return yesNoDecisionName;
            }
            set
            {
                yesNoDecisionName = value;
                OnPropertyChanged(nameof(ValueName));
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
}
