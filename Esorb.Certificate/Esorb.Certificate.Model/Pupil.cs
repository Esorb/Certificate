using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.School_Certificate.Model
{
    public class Pupil
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
            get { return pupilId; }
            set { pupilId = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public DateOnly DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public short YearsAtSchool
        {
            get { return yearsAtSchool; }
            set { yearsAtSchool = value; }
        }

        public long SchoolClassId
        {
            get { return schoolClassId; }
            set { schoolClassId = value; }
        }

        public string FullName
        {
            get { return string.Format("{0} {1}", firstName, lastName); }
        }

        public SchoolClass? SchoolClass
        {
            get { return schoolClass; }
            set { schoolClass = value; }
        }
    }
}
