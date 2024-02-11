using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.Model;
using Esorb.Certificate.App.Model.Enumerables;
using Esorb.Certificate.App.PupilCsvFileService;
using Esorb.Certificate.App.ViewModel;
using Esorb.Certificate.App.InitialLoad;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Esorb.Certificate.App.ViewModel;

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
            // Hier rufe deine Funktion mit dem Dateinamen auf
            // Beispiel: ProcessSelectedFile(selectedFileName);
        }
    }
}
