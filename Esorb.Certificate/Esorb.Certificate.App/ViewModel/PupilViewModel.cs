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
        this.pupil = pupil;
        schoolClass = new SchoolClassViewModel(pupil.SchoolClass!);
    }

    private Pupil pupil;
    private SchoolClassViewModel schoolClass;

    public string FirstName
    {
        get => pupil.FirstName;
        set
        {
            if (pupil.FirstName != value)
            {
                pupil.FirstName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }
    }
    public string LastName
    {
        get => pupil.LastName;
        set
        {
            if (pupil.LastName != value)
            {
                pupil.LastName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }
    }
    public DateTime DateOfBirth
    {
        get => pupil.DateOfBirth;
        set
        {
            if (pupil.DateOfBirth != value)
            {
                pupil.DateOfBirth = value;
                OnPropertyChanged();
            }
        }
    }
    public int YearsAtSchool
    {
        get => pupil.YearsAtSchool;
        set
        {
            if (pupil.YearsAtSchool != value)
            {
                pupil.YearsAtSchool = value;
                OnPropertyChanged();
            }
        }
    }
    public string SchoolClassId
    {
        get => pupil.SchoolClassId;
        set
        {
            if (pupil.SchoolClassId != value)
            {
                pupil.SchoolClassId = value;
                OnPropertyChanged();
            }
        }
    }
    public string FullName
    {
        get => pupil.FullName;
    }
    public SchoolClassViewModel SchoolClass
    {
        get => schoolClass;
        set => schoolClass = value;
    }
}
