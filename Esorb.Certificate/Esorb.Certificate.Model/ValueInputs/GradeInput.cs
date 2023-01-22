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
    public class GradeInput : ViewModelBase, IValueInput
    {
        private long gradeInputID;
        private long inputContextID;
        private string gradeImputName;
        private string gradeInputValue;
        private InputContext? context;

        public GradeInput()
        {
            gradeImputName = string.Empty;
            gradeInputValue = string.Empty;
        }

        public long GradeInputID
        {
            get
            {
                return gradeInputID;
            }
            set
            {
                gradeInputID = value;
                OnPropertyChanged(nameof(GradeInputID));
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
                return gradeImputName;
            }
            set
            {
                gradeImputName = value;
                OnPropertyChanged(nameof(ValueName));
            }
        }

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
