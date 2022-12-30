﻿using Esorb.Certificate.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.Model
{
    public class CertificateData : ViewModelBase
    {
        private long certificateDataId;
        private string? schoolYear;
        private short halfYear;
        private DateOnly dateOfSchoolConference;
        private DateOnly dateOfCertificateDistribution;
        private DateOnly dateOfRestartLessons;
        private TimeOnly timeOfRestartLessons;
        private long certificateTemplateID;
        private CertificateTemplate? template;

        public CertificateData()
        {
        }

        public long CertificateDataId
        {
            get
            {
                return certificateDataId;
            }
            set
            {
                certificateDataId = value;
                OnPropertyChanged(nameof(CertificateDataId));
            }
        }

        public string? SchoolYear
        {
            get
            {
                return schoolYear;
            }
            set
            {
                schoolYear = value;
                OnPropertyChanged(nameof(SchoolYear));
            }
        }

        public short HalfYear
        {
            get
            {
                return halfYear;
            }
            set
            {
                halfYear = value;
                OnPropertyChanged(nameof(HalfYear));
            }
        }

        public DateOnly DateOfSchoolConference
        {
            get
            {
                return dateOfSchoolConference;
            }
            set
            {
                dateOfSchoolConference = value;
                OnPropertyChanged(nameof(DateOfSchoolConference));
            }
        }

        public DateOnly DateOfCertificateDistribution
        {
            get
            {
                return dateOfCertificateDistribution;
            }
            set
            {
                dateOfCertificateDistribution = value;
                OnPropertyChanged(nameof(DateOfCertificateDistribution));
            }
        }

        public DateOnly DateOfRestartLessons
        {
            get
            {
                return dateOfRestartLessons;
            }
            set
            {
                dateOfRestartLessons = value;
                OnPropertyChanged(nameof(DateOfRestartLessons));
            }
        }

        public TimeOnly TimeOfRestartLessons
        {
            get
            {
                return timeOfRestartLessons;
            }
            set
            {
                timeOfRestartLessons = value;
                OnPropertyChanged(nameof(TimeOfRestartLessons));
            }
        }
        public long CertificateTemplateID
        {
            get { return certificateTemplateID; }
            set { certificateTemplateID = value; }
        }


        public CertificateTemplate? Template
        {
            get { return template; }
            set { template = value; }
        }


    }
}