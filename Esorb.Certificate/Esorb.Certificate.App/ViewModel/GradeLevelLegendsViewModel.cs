using CommunityToolkit.Mvvm.ComponentModel;
using Esorb.Certificate.App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.ViewModel;

public class GradeLevelLegendsViewModell : ObservableObject
{
    public GradeLevelLegendsViewModell(CertificateModel certificateModel)
    {
        this.certificateModel = certificateModel;
        BuildGradeLevelLegendsViewModel();
    }
    public ObservableCollection<GradeLevelLegendViewModel> GradeLevelLegends { get; set; }

    private CertificateModel certificateModel;
    private void BuildGradeLevelLegendsViewModel()
    {
        GradeLevelLegends = new ObservableCollection<GradeLevelLegendViewModel>();

        foreach (var gl in certificateModel.GradeLimits)
        {
            GradeLevelLegends.Add(new GradeLevelLegendViewModel(gl, certificateModel.DbHelper));
        }
    }
}
