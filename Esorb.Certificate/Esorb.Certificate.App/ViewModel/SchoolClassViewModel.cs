using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esorb.Certificate.App.Model;

namespace Esorb.Certificate.App.ViewModel;

[ObservableObject]
public partial class SchoolClassViewModel
{

    public SchoolClassViewModel(SchoolClass schoolClass)
    {
        _schoolClass = schoolClass;
    }

    private SchoolClass _schoolClass;
}

