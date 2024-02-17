using CommunityToolkit.Mvvm.ComponentModel;
using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.ViewModel;

public class GradeLimitsViewModel : ObservableObject
{
    public GradeLimitsViewModel(CertificateModel certificateModel)
    {
        this.certificateModel = certificateModel;
        dbHelper = DbHelper.GetInstance();
        BuildGradeLimitsViewModel();
    }

    public ObservableCollection<GradeLimitViewModel> GradeLimits { get; set; }

    private CertificateModel certificateModel;
    private DbHelper dbHelper;
    private void BuildGradeLimitsViewModel()
    {
        GradeLimits = new ObservableCollection<GradeLimitViewModel>();

        foreach (var gl in certificateModel.GradeLimits)
        {
            GradeLimits.Add(new GradeLimitViewModel(gl, dbHelper));
        }
    }
}
