using Esorb.Certificate.Basics;
using Esorb.Certificate.Model.Interfaces;
using System.ComponentModel.Design;

namespace Esorb.Certificate.Model
{
    public class NumberOfHours : ViewModelBase, IValueInput
    {
        private long numberOfHoursID;
        private long pupilID;
        private long certificateID;
        private long contentID;
        private string numberOfHoursName;
        private int quantity;

        public NumberOfHours()
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
        public long PupilID
        {
            get
            {
                return pupilID;
            }
            set
            {
                pupilID = value;
                OnPropertyChanged(nameof(PupilID));
            }
        }

        public long CertificateID
        {
            get
            {
                return certificateID;
            }
            set
            {
                certificateID = value;
                OnPropertyChanged(nameof(CertificateID));
            }
        }

        public long ContentID
        {
            get
            {
                return contentID;
            }
            set
            {
                contentID = value;
                OnPropertyChanged(nameof(ContentID));
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
                return quantity.ToString();
            }
            set
            {
                if (int.TryParse(value, out quantity))
                {
                    if (quantity < 0)
                    {
                        quantity = 0;
                    }
                }
                else
                {
                    quantity = 0;
                }
                OnPropertyChanged(nameof(ValueString));
            }
        }
    }
}
