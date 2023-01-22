using Esorb.Certificate.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esorb.Certificate.Model.Enumerables;

namespace Esorb.Certificate.Model
{
    public class Teacher : ViewModelBase
    {
        private long teacherId;
        private string firstName;
        private string lastName;
        private GenderValues gender;
        private Boolean isHeadmaster;
        private Boolean isAdmin;
        private string password;

        public Teacher()
        {
            firstName = string.Empty;
            lastName = string.Empty;
            isHeadmaster = false;
            isAdmin = false;
            password = string.Empty;
        }

        public long TeacherId
        {
            get
            {
                return teacherId;
            }
            set
            {
                teacherId = value;
                OnPropertyChanged(nameof(TeacherId));
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public GenderValues Gender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        public Boolean IsHeadmaster
        {
            get
            {
                return isHeadmaster;
            }
            set
            {
                isHeadmaster = value;
                OnPropertyChanged(nameof(IsHeadmaster));
            }
        }

        public Boolean IsAdmin
        {
            get
            {
                return isAdmin;
            }
            set
            {
                isAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
    }
}
