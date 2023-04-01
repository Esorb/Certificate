using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.Model;

namespace Esorb.Certificate.App.ViewModel;

public partial class CertificateDataViewModel : ObservableObject, ICertificateDataViewModel
{
    private CertificateData _certificateData;
    private DbHelper _dbHelper;

    public CertificateDataViewModel(CertificateData certificateData, DbHelper dbHelper)
    {
        _certificateData = certificateData;
        _dbHelper = dbHelper;
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
                _dbHelper.Save(_certificateData);
            }
        }
    }
    public int HalfYear
    {
        get => _certificateData.HalfYear;
        set
        {
            if (value != _certificateData.HalfYear)
            {
                _certificateData.HalfYear = value;
                OnPropertyChanged();
                _dbHelper.Save(_certificateData);
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
                _dbHelper.Save(_certificateData);
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
                _dbHelper.Save(_certificateData);
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
                _dbHelper.Save(_certificateData);
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
                _dbHelper.Save(_certificateData);
            }
        }
    }
}
