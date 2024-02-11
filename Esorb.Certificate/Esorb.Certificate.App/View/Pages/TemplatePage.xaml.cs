using Esorb.Certificate.App.ViewModel;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using Esorb.Certificate.App.Excel;

namespace Esorb.Certificate.App.View.Pages;

/// <summary>
/// Interaktionslogik für InfoPage.xaml
/// </summary>
public partial class TemplatePage : Page
{
    public readonly CertificateTemplatesViewModel certifcateTemplatesViewModel;

    public TemplatePage(CertificateTemplatesViewModel certifcateTemplatesViewModel)
    {
        InitializeComponent();
        this.certifcateTemplatesViewModel = certifcateTemplatesViewModel;
        DataContext = this.certifcateTemplatesViewModel;
    }

    private void LoadExcelCertificateMaster_Click(object sender, RoutedEventArgs e)
    {
        var openFileDialog = new OpenFileDialog();
        openFileDialog.Title = "Zeugnis-Master auswählen";
        openFileDialog.Filter = "Excel Dateien (*.xlsx)|*.xlsx";

        if (openFileDialog.ShowDialog() == true)
        {
            string selectedFileName = openFileDialog.FileName;
            CertificateMasterLoader certificateMasterLoader = new();
            certificateMasterLoader.UpdateCertificateTemplates(selectedFileName);
        }
    }
}
