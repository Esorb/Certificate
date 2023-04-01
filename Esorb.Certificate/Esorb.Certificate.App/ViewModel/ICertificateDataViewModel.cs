using System;

namespace Esorb.Certificate.App.ViewModel
{
    public interface ICertificateDataViewModel
    {
        DateTime DateOfCertificateDistribution { get; set; }
        DateTime DateOfRestartLessons { get; set; }
        DateTime DateOfSchoolConference { get; set; }
        int HalfYear { get; set; }
        string SchoolYear { get; set; }
        DateTime TimeOfRestartLessons { get; set; }
    }
}