using Esorb.Certificate.App.Model;
using Esorb.Certificate.App.Model.Enumerables;
using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.ViewModel;

public partial class TeacherViewModel : ObservableObject
{
    TeacherViewModel(Teacher teacher)
    {
        _teacher = teacher;
    }

    private Teacher _teacher { get; }

    public string FirstName
    {
        get => _teacher.FirstName;
        set
        {
            if (_teacher.FirstName != value)
            {
                _teacher.FirstName = value;
                OnPropertyChanged();
                OnPropertyChanged("FullName");
            }
        }
    }
    public string LastName
    {
        get => _teacher.LastName;
        set
        {
            if (_teacher.LastName != value)
            {
                _teacher.LastName = value;
                OnPropertyChanged();
                OnPropertyChanged("FullName");
            }
        }
    }
    public GenderValues Gender
    {
        get => _teacher.Gender;
        set
        {
            if (_teacher.Gender != value)
            {
                _teacher.Gender = value;
                OnPropertyChanged();
            }
        }
    }
    public Boolean IsHeadmaster
    {
        get => _teacher.IsHeadmaster;
        set
        {
            if (_teacher.IsHeadmaster != value)
            {
                _teacher.IsHeadmaster = value;
                OnPropertyChanged();
            }
        }
    }
    public Boolean IsAdmin
    {
        get => _teacher.IsAdmin;
        set
        {
            if (_teacher.IsAdmin != value)
            {
                _teacher.IsAdmin = value;
                OnPropertyChanged();
            }
        }
    }
    public string Password
    {
        get => _teacher.Password;
        set
        {
            if (_teacher.Password != value)
            {
                _teacher.Password = value;
                OnPropertyChanged();
            }
        }
    }
    public string FullName

    {
        get => _teacher.FullName;
    }

}
