using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.Model
{
    public class CertificateData
    {
        private long certificateDataId;
        private short schoolYear;
        private short halfYear;
        private DateOnly dateOfSchoolConference;
        private DateOnly dateOfCertificateDistribution;
        private DateOnly dateOfRestartLessons;
        private TimeOnly timeOfRestartLessons;

        public CertificateData()
        {
        }

        public long CertificateDataId
        {
            get { return certificateDataId; }
            set { certificateDataId = value; }
        }

        public short SchoolYear
        {
            get { return schoolYear; }
            set { schoolYear = value; }
        }

        public short HalfYear
        {
            get { return halfYear; }
            set { halfYear = value; }
        }

        public DateOnly DateOfSchoolConference
        {
            get { return dateOfSchoolConference; }
            set { dateOfSchoolConference = value; }
        }

        public DateOnly DateOfCertificateDistribution
        {
            get { return dateOfCertificateDistribution; }
            set { dateOfCertificateDistribution = value; }
        }

        public DateOnly DateOfRestartLessons
        {
            get { return dateOfRestartLessons; }
            set { dateOfRestartLessons = value; }
        }

        public TimeOnly TimeOfRestartLessons
        {
            get { return timeOfRestartLessons; }
            set { timeOfRestartLessons = value; }
        }

    }
}
