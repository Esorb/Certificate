using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Esorb.Certificate.App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.ViewModel;

[ObservableObject]
public partial class CertificateViewModell
{
    //private CertificateData certificateData = new();

    //public CertificateData CertificateData
    //{
    //    get
    //    {
    //        return certificateData;
    //    }
    //    set
    //    {
    //        certificateData = value;
    //        OnPropertyChanged(nameof(certificateData));
    //    }
    //}

    //private ObservableCollection<SchoolClass> schoolClasses = new();

    //public ObservableCollection<SchoolClass> SchoolClasses
    //{
    //    get
    //    {
    //        return schoolClasses;
    //    }
    //    set
    //    {
    //        schoolClasses = value;
    //    }
    //}

    private ObservableCollection<TeacherViewModel> teachers = new();

    public ObservableCollection<TeacherViewModel> Teachers
    {
        get
        {
            return teachers;
        }
        set
        {
            teachers = value;
        }
    }

}
