using Esorb.Certificate.App.Model;
using Esorb.Certificate.App.Model.Enumerables;
using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esorb.Certificate.App.Database;

namespace Esorb.Certificate.App.ViewModel;

public partial class TeacherViewModel : ObservableObject
{
    public TeacherViewModel(Teacher teacher, DbHelper dbHelper)
    {
        Teacher = teacher;
        DbHelper = dbHelper;
    }

    private Teacher Teacher { get; }
    private DbHelper DbHelper { get; }

    public string FirstName
    {
        get => Teacher.FirstName;
        set
        {
            if (Teacher.FirstName != value)
            {
                Teacher.FirstName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
                DbHelper.Save(Teacher);
            }
        }
    }
    public string LastName
    {
        get => Teacher.LastName;
        set
        {
            if (Teacher.LastName != value)
            {
                Teacher.LastName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
                DbHelper.Save(Teacher);
            }
        }
    }
    public GenderValues Gender
    {
        get => Teacher.Gender;
        set
        {
            if (Teacher.Gender != value)
            {
                Teacher.Gender = value;
                OnPropertyChanged();
                DbHelper.Save(Teacher);
            }
        }
    }
    public Boolean IsHeadmaster
    {
        get => Teacher.IsHeadmaster;
        set
        {
            if (Teacher.IsHeadmaster != value)
            {
                Teacher.IsHeadmaster = value;
                OnPropertyChanged();
                DbHelper.Save(Teacher);
            }
        }
    }
    public Boolean IsAdmin
    {
        get => Teacher.IsAdmin;
        set
        {
            if (Teacher.IsAdmin != value)
            {
                Teacher.IsAdmin = value;
                OnPropertyChanged();
                DbHelper.Save(Teacher);
            }
        }
    }
    public string Password
    {
        get => Teacher.Password;
        set
        {
            if (Teacher.Password != value)
            {
                Teacher.Password = value;
                OnPropertyChanged();
                DbHelper.Save(Teacher);
            }
        }
    }
    public string FullName

    {
        get => Teacher.FullName;
    }

    public void Delete()
    {
        DbHelper.Delete(Teacher);
    }

}
