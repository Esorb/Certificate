using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Esorb.Certificate.App.Model;

namespace Esorb.Certificate.App.ViewModel;

public partial class CertificateDataViewModel : ObservableObject
{
    private CertificateData _certificateData;
    public CertificateDataViewModel(CertificateData certificateData)
    {
        _certificateData = certificateData;
    }

    public string SchoolYear
    {
        get => _certificateData.SchoolYear;
        set
        {
            if (value != _certificateData.SchoolYear)
            {
                _certificateData.SchoolYear = value;
                OnPropertyChanged();
            }
        }
    }
    public short HalfYear
    {
        get => _certificateData.HalfYear;
        set
        {
            if (value != _certificateData.HalfYear)
            {
                _certificateData.HalfYear = value;
                OnPropertyChanged();
            }
        }
    }
    public DateTime DateOfSchoolConference
    {
        get => _certificateData.DateOfSchoolConference;
        set
        {
            if (value != _certificateData.DateOfSchoolConference)
            {
                _certificateData.DateOfSchoolConference = value;
                OnPropertyChanged();
            }
        }
    }
    public DateTime DateOfCertificateDistribution
    {
        get => _certificateData.DateOfCertificateDistribution;
        set
        {
            if (value != _certificateData.DateOfCertificateDistribution)
            {
                _certificateData.DateOfCertificateDistribution = value;
                OnPropertyChanged();
            }
        }
    }
    public DateTime DateOfRestartLessons
    {
        get => _certificateData.DateOfRestartLessons;
        set
        {
            if (value != _certificateData.DateOfRestartLessons)
            {
                _certificateData.DateOfRestartLessons = value;
                OnPropertyChanged();
            }
        }
    }
    public DateTime TimeOfRestartLessons
    {
        get => _certificateData.TimeOfRestartLessons;
        set
        {
            if (value != _certificateData.TimeOfRestartLessons)
            {
                _certificateData.TimeOfRestartLessons = value;
                OnPropertyChanged();
            }
        }
    }

}
