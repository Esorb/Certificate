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
        _schoolClass = schoolClass;
    }
    public ObservableCollection<PupilViewModel> Pupils
    {
        get { return pupils; }
        set { pupils = value; }
    }
    public string ClassName
    {
        get => _schoolClass.ClassName;
        set
        {
            if (_schoolClass.ClassName != value)
            {
                _schoolClass.ClassName = value;
                OnPropertyChanged();
            }
        }

    }
    public int Yearlevel
    {
        get => _schoolClass.Yearlevel;
        set
        {
            if (_schoolClass.Yearlevel != value)
            {
                _schoolClass.Yearlevel = value;
                OnPropertyChanged();
            }
        }
    }
    public int HalfYear
    {
        get => _schoolClass.HalfYear;
        set
        {
            if (_schoolClass.HalfYear != value)
            {
                _schoolClass.HalfYear = value;
                OnPropertyChanged();
            }
        }
    }

    private SchoolClass _schoolClass;
    private ObservableCollection<PupilViewModel> pupils = new ObservableCollection<PupilViewModel>();
}

