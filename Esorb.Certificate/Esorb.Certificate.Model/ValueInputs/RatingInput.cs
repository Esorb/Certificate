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
    public class RatingInput : ViewModelBase, IValueInput
    {
        private long ratingInputID;
        private long inputContextID;
        private string ratingInputName;
        private string ratingInputValue;
        private InputContext? context;

        public RatingInput()
        {
            ratingInputName = string.Empty;
            ratingInputValue = string.Empty;
        }

        public long RatingInputID
        {
            get
            {
                return ratingInputID;
            }
            set
            {
                ratingInputID = value;
                OnPropertyChanged(nameof(RatingInputID));
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
                return ratingInputName;
            }
            set
            {
                ratingInputName = value;
                OnPropertyChanged(nameof(ValueName));
            }
        }

        public string ValueString
        {
            get
            {
                return ratingInputValue;
            }
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
