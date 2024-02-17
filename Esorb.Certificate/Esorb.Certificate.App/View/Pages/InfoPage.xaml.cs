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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Esorb.Certificate.App.View.Pages;

/// <summary>
/// Interaktionslogik für InfoPage.xaml
/// </summary>
public partial class InfoPage : Page
{
    public readonly CertifcateViewModel certifcateViewModel;

    public InfoPage(CertifcateViewModel certifcateViewModel)
    {
        InitializeComponent();
        this.certifcateViewModel = certifcateViewModel;
        DataContext = this.certifcateViewModel;
    }

    private void GitHubButton_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            string url = "https://github.com/Esorb/Certificate";
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}"));
        }
        catch (System.ComponentModel.Win32Exception noBrowser)
        {
            if (noBrowser.ErrorCode == -2147467259)
                System.Windows.MessageBox.Show(noBrowser.Message);
        }
        catch (System.Exception other)
        {
            System.Windows.MessageBox.Show(other.Message);
        }
    }

    private void TestBtn_Click(object sender, RoutedEventArgs e)
    {
        var psci = new PupilSchoolClassImporter();
        psci.ImportPupilsAndSchoolClasses("C:/Users/frank/source/repos/Esorb/Certificate/Esorb.Certificate/Esorb.Certificate.UnitTests/TestData/PupilsClassesTest.csv");
        var cm = CertificateModel.GetInstance();
        cm.LoadCertificateModel();
        _ = MessageBox.Show("Test!");

    }

    private void FillDatabase_Click(object sender, RoutedEventArgs e)
    {
        InitialLoader il = new();
        InitialLoader.Load();
    }
}
