using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Esorb.Certificate.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.ViewModel;

public partial class PupilViewModel : ObservableObject
{
    public PupilViewModel(Pupil pupil)
    {
        _pupil = pupil;
        _schoolClass = new SchoolClassViewModel(_pupil.SchoolClass!);
    }

    private Pupil _pupil;
    private SchoolClassViewModel _schoolClass;

    public string FirstName
    {
        get => _pupil.FirstName;
        set
        {
            if (_pupil.FirstName != value)
            {
                _pupil.FirstName = value;
                OnPropertyChanged();
                OnPropertyChanged("FullName");
            }
        }
    }
    public string LastName
    {
        get => _pupil.LastName;
        set
        {
            if (_pupil.LastName != value)
            {
                _pupil.LastName = value;
                OnPropertyChanged();
                OnPropertyChanged("FullName");
            }
        }
    }
    public DateTime DateOfBirth
    {
        get => _pupil.DateOfBirth;
        set
        {
            if (_pupil.DateOfBirth != value)
            {
                _pupil.DateOfBirth = value;
                OnPropertyChanged();
            }
        }
    }
    public int YearsAtSchool
    {
        get => _pupil.YearsAtSchool;
        set
        {
            if (_pupil.YearsAtSchool != value)
            {
                _pupil.YearsAtSchool = value;
            }
        }
    }
    public string SchoolClassId
    {
        get => _pupil.SchoolClassId;
        set
        {
            if (_pupil.SchoolClassId != value)
            {
                _pupil.SchoolClassId = value;
                OnPropertyChanged();
            }
        }
    }
    public string FullName
    {
        get => _pupil.FullName;
    }
    public SchoolClassViewModel? SchoolClass
    {
        get => _schoolClass;
    }
}
