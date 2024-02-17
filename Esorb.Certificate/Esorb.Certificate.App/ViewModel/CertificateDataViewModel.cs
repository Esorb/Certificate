using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.Model;

namespace Esorb.Certificate.App.ViewModel;

public partial class CertificateDataViewModel : ObservableObject
{
    private CertificateData certificateData;
    private DbHelper dbHelper;

    public List<String> SchoolYearChoices = new();
    public List<int> HalfYearChoices = new();

    private void PrepareSchoolYearChoices()
    {
        int currentYear = DateTime.Now.Year;
        SchoolYearChoices.Add($"{currentYear - 1} / {currentYear}");
        SchoolYearChoices.Add($"{currentYear} / {currentYear + 1}");
        if (!SchoolYearChoices.Contains(SchoolYear))
        {
            SchoolYearChoices.Add(SchoolYear);
        }
        OnPropertyChanged(nameof(SchoolYearChoices));
        HalfYearChoices.Add(1);
        HalfYearChoices.Add(2);
        OnPropertyChanged(nameof(HalfYearChoices));
    }
    public CertificateDataViewModel(CertificateModel certificateModel)
    {
        certificateData = certificateModel.CertificateData;
        dbHelper = DbHelper.GetInstance();
        PrepareSchoolYearChoices();
    }

    public string SchoolYear
    {
        get => certificateData.SchoolYear;
        set
        {
            if (value != certificateData.SchoolYear)
            {
                certificateData.SchoolYear = value;
                OnPropertyChanged();
                dbHelper.Save(certificateData);
            }
        }
    }
    public int HalfYear
    {
        get => certificateData.HalfYear;
        set
        {
            if (value != certificateData.HalfYear)
            {
                certificateData.HalfYear = value;
                OnPropertyChanged();
                dbHelper.Save(certificateData);
            }
        }
    }
    public DateTime DateOfSchoolConference
    {
        get => certificateData.DateOfSchoolConference;
        set
        {
            if (value != certificateData.DateOfSchoolConference)
            {
                certificateData.DateOfSchoolConference = value;
                OnPropertyChanged();
                dbHelper.Save(certificateData);
            }
        }
    }
    public DateTime DateOfCertificateDistribution
    {
        get => certificateData.DateOfCertificateDistribution;
        set
        {
            if (value != certificateData.DateOfCertificateDistribution)
            {
                certificateData.DateOfCertificateDistribution = value;
                OnPropertyChanged();
                dbHelper.Save(certificateData);
            }
        }
    }
    public DateTime DateOfRestartLessons
    {
        get => certificateData.DateOfRestartLessons;
        set
        {
            if (value != certificateData.DateOfRestartLessons)
            {
                certificateData.DateOfRestartLessons = value;
                OnPropertyChanged();
                dbHelper.Save(certificateData);
            }
        }
    }
    public DateTime TimeOfRestartLessons
    {
        get => certificateData.TimeOfRestartLessons;
        set
        {
            if (value != certificateData.TimeOfRestartLessons)
            {
                certificateData.TimeOfRestartLessons = value;
                OnPropertyChanged();
                dbHelper.Save(certificateData);
            }
        }
    }
}
