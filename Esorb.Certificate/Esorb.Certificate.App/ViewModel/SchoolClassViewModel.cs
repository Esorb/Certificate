using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esorb.Certificate.App.Model;
using System.Collections.ObjectModel;

namespace Esorb.Certificate.App.ViewModel;

public partial class SchoolClassViewModel : ObservableObject
{

    public SchoolClassViewModel(SchoolClass schoolClass)
    {
        this.schoolClass = schoolClass;
    }
    public ObservableCollection<PupilViewModel> Pupils
    {
        get { return pupils; }
        set { pupils = value; }
    }
    public string ID => schoolClass.ID!;
    public string ClassName
    {
        get => schoolClass.ClassName;
        set
        {
            if (schoolClass.ClassName != value)
            {
                schoolClass.ClassName = value;
                OnPropertyChanged();
            }
        }
    }
    public int Yearlevel
    {
        get => schoolClass.Yearlevel;
        set
        {
            if (schoolClass.Yearlevel != value)
            {
                schoolClass.Yearlevel = value;
                OnPropertyChanged();
            }
        }
    }
    public int HalfYear
    {
        get => schoolClass.HalfYear;
        set
        {
            if (schoolClass.HalfYear != value)
            {
                schoolClass.HalfYear = value;
                OnPropertyChanged();
            }
        }
    }

    private SchoolClass schoolClass;
    private ObservableCollection<PupilViewModel> pupils = new();
}

