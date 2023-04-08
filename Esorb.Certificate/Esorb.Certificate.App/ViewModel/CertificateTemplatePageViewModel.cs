using CommunityToolkit.Mvvm.ComponentModel;
using Esorb.Certificate.App.View.Pages;
using Esorb.Certificate.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esorb.Certificate.App.Database;

namespace Esorb.Certificate.App.ViewModel;

public partial class CertificateTemplatePageViewModel : ObservableObject
{
    private CertificateTemplatePage CertificateTemplatePage { get; set; }
    private DbHelper DbHelper { get; set; }

    public CertificateTemplatePageViewModel(CertificateTemplatePage certificateTemplatePage, DbHelper dbHelper)
    {
        CertificateTemplatePage = certificateTemplatePage;
        DbHelper = dbHelper;
    }
    public int PagNumber
    {
        get => CertificateTemplatePage.PageNumber;
        set
        {
            if (CertificateTemplatePage.PageNumber != value)
            {
                CertificateTemplatePage.PageNumber = value;
                OnPropertyChanged();
                Save();
            }
        }
    }

    public CertificateTemplateViewModel CertificateTemplate { get; set; }

    public void Save()
    {
        DbHelper.Save(CertificateTemplatePage);
    }
}
