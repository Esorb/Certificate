using Esorb.Certificate.Basics;
using Esorb.Certificate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.School_Certificate.Model
{
    public class Pupil : ViewModelBase
    {
        private long pupilId;
        private string firstName;
        private string lastName;
        private DateOnly dateOfBirth;
        private short yearsAtSchool;
        private long schoolClassId;
        private SchoolClass? schoolClass;

        public Pupil()
        {
            firstName = string.Empty;
            lastName = string.Empty;
        }

        public long PupilId
        {
            get
            {
                return pupilId;
            }
            set
            {
                pupilId = value;
                OnPropertyChanged(nameof(PupilId));
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

        public DateOnly DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
            }
        }

        public short YearsAtSchool
        {
            get
            {
                return yearsAtSchool;
            }
            set
            {
                yearsAtSchool = value;
                OnPropertyChanged(nameof(YearsAtSchool));
            }
        }

        public long SchoolClassId
        {
            get
            {
                return schoolClassId;
            }
            set
            {
                schoolClassId = value;
                OnPropertyChanged(nameof(SchoolClassId));
            }
        }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", firstName, lastName);
            }
        }

        public SchoolClass? SchoolClass
        {
            get
            {
                return schoolClass;
            }
            set
            {
                schoolClass = value;
                OnPropertyChanged(nameof(SchoolClass));
            }
        }
    }
}
