using CommunityToolkit.Mvvm.ComponentModel;
using Esorb.Certificate.App.View.Pages;
using Esorb.Certificate.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esorb.Certificate.App.Database;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using System.Windows.Input;
using Esorb.Certificate.App.View.Windows;

namespace Esorb.Certificate.App.ViewModel;

public partial class CertificateTemplatePageViewModel : ObservableObject
{
    public CertificateTemplatePage CertificateTemplatePage { get; set; }
    private DbHelper DbHelper { get; set; }

    public CertificateTemplatePageViewModel(CertificateTemplatePage certificateTemplatePage, DbHelper dbHelper)
    {
        CertificateTemplatePage = certificateTemplatePage;
        DbHelper = dbHelper;
        RemoveCertificateTemplatePage = new RelayCommand(ExecuteRemoveCertificateTemplatePage, CanExecuteRemoveCertificateTemplatePage);
        PreviewCertificateTemplatePage = new RelayCommand(ExecutePreviewCertificateTemplatePage, CanExecutePreviewCertificateTemplatePage);
    }
    public RelayCommand RemoveCertificateTemplatePage { get; private set; }
    public RelayCommand PreviewCertificateTemplatePage { get; private set; }
    public int PageNumber
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

    public bool CanBeMovedUp => PageNumber > 1;
    public bool CanBeMovedDown => PageNumber < CertificateTemplateViewModel.CertificateTemplatePages.Count;
    public CertificateTemplateViewModel CertificateTemplateViewModel { get; set; }

    public void Save()
    {
        DbHelper.Save(CertificateTemplatePage);
    }
    private void ExecuteRemoveCertificateTemplatePage()
    {
        CertificateTemplateViewModel.RemoveCertificateTemplatePage(this);
        OnPropertyChanged(nameof(CanBeMovedUp));
        OnPropertyChanged(nameof(CanBeMovedDown));
        CommandManager.InvalidateRequerySuggested();
    }
    private bool CanExecuteRemoveCertificateTemplatePage()
    {
        return true;
    }

    private void ExecutePreviewCertificateTemplatePage()
    {
        var previewWindow = new CertificateTemplatePagePreviewWindow();
        previewWindow.DataContext = this;
        var sb = new StringBuilder();
        sb.Append(CertificateTemplateViewModel.TemplateName);
        previewWindow.Title = sb.ToString();
        previewWindow.Show();
    }

    private bool CanExecutePreviewCertificateTemplatePage()
    {
        return true;
    }
}
