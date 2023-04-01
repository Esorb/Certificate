using System;

namespace Esorb.Certificate.App.Model
{
    public interface ICertificateData
    {
        DateTime DateOfCertificateDistribution { get; set; }
        DateTime DateOfRestartLessons { get; set; }
        DateTime DateOfSchoolConference { get; set; }
        int HalfYear { get; set; }
        string SchoolYear { get; set; }
        DateTime TimeOfRestartLessons { get; set; }
    }
}