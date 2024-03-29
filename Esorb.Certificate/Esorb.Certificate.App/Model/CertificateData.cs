﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.Model;

public class CertificateData : PersistentObject
{
    public CertificateData()
    {
        DateOfSchoolConference = DateTime.SpecifyKind(DateTime.MinValue, DateTimeKind.Utc);
        DateOfCertificateDistribution = DateTime.SpecifyKind(DateTime.MinValue, DateTimeKind.Utc);
        DateOfRestartLessons = DateTime.SpecifyKind(DateTime.MinValue, DateTimeKind.Utc);
        TimeOfRestartLessons = DateTime.SpecifyKind(DateTime.MinValue, DateTimeKind.Utc);
    }

    public string SchoolYear { get; set; } = string.Empty;
    public int HalfYear { get; set; }
    public DateTime DateOfSchoolConference { get; set; }
    public DateTime DateOfCertificateDistribution { get; set; }
    public DateTime DateOfRestartLessons { get; set; }
    public DateTime TimeOfRestartLessons { get; set; }
}
