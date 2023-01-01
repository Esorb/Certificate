using Esorb.Certificate.Basics;
using Esorb.Certificate.Model.Interfaces;
using Esorb.School_Certificate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.Model.ValueInputs
{
    public class SubjectDecisionInput : ViewModelBase, IValueInput
    {
        private long subjectDecisionID;
        private long inputContextID;
        private string subjectDecisionName;
        private string subjectDecisionValue;
        private long subjectAlternativeGroupID;
        private SubjectAlternativeGroup? subjectAlternativeGroup;
        private InputContext? context;

        public SubjectDecisionInput()
        {
            subjectDecisionName = string.Empty;
            subjectDecisionValue = string.Empty;
        }

        public long SubjectDecisionID
        {
            get
            {
                return subjectDecisionID;
            }
            set
            {
                subjectDecisionID = value;
                OnPropertyChanged(nameof(SubjectDecisionID));
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
                return subjectDecisionName;
            }
            set
            {
                subjectDecisionName = value;
                OnPropertyChanged(nameof(ValueName));
            }
        }

        public string ValueString
        {
            get
            {
                return subjectDecisionValue;
            }
            set
            {
                subjectDecisionValue = value;
                OnPropertyChanged(nameof(ValueString));
            }
        }

        public long SubjectAlternativeGroupID
        {
            get
            {
                return subjectAlternativeGroupID;
            }
            set
            {
                subjectAlternativeGroupID = value;
                OnPropertyChanged(nameof(SubjectAlternativeGroupID));
            }
        }

        public SubjectAlternativeGroup? SubjectAlternativeGroup
        {
            get
            {
                return subjectAlternativeGroup;
            }
            set
            {
                subjectAlternativeGroup = value;
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
