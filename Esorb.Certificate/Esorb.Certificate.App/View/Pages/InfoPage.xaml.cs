using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.Model;
using Esorb.Certificate.App.Model.Enumerables;
using Esorb.Certificate.App.PupilCsvFileService;
using Esorb.Certificate.App.ViewModel;
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
        _ = MessageBox.Show("Test!");
    }

    private void FillDatabase_Click(object sender, RoutedEventArgs e)
    {
        CreateEmptyCertificateDatabase();
        LoadPupilsAndSchoolClassesIntoDatabase();
        CreateTeachers();
        CreateCertificateTemplates();
        CreateCertificateTemplatePages();
    }

    private void LoadPupilsAndSchoolClassesIntoDatabase()
    {
        var psci = new PupilSchoolClassImporter();
        psci.ImportPupilsAndSchoolClasses("C:/Users/frank/source/repos/Esorb/Certificate/Esorb.Certificate/Esorb.Certificate.UnitTests/TestData/PupilsClassesTest.csv");
    }

    private void CreateEmptyCertificateDatabase()
    {
        var dbh = new DbHelper();
        dbh.DropCertificateTables();
        dbh.CreateCertificateTables();
    }

    private void CreateCertificateTemplates()
    {
        var dbh = new DbHelper();

        CertificateTemplate ct1 = new();
        CertificateTemplate ct2 = new();
        CertificateTemplate ct3 = new();
        CertificateTemplate ct4 = new();
        CertificateTemplate ct5 = new();
        CertificateTemplate ct6 = new();
        CertificateTemplateViewModel ct1VM = new(ct1, dbh);
        CertificateTemplateViewModel ct2VM = new(ct2, dbh);
        CertificateTemplateViewModel ct3VM = new(ct3, dbh);
        CertificateTemplateViewModel ct4VM = new(ct4, dbh);
        CertificateTemplateViewModel ct5VM = new(ct5, dbh);
        CertificateTemplateViewModel ct6VM = new(ct6, dbh);

        ct1VM.Yearlevel = 1;
        ct1VM.IsFullYearReport = true;
        ct2VM.Yearlevel = 2;
        ct2VM.IsFullYearReport = true;
        ct3VM.Yearlevel = 3;
        ct3VM.HalfYear = 1;
        ct3VM.IsFullYearReport = false;
        ct4VM.Yearlevel = 3;
        ct4VM.HalfYear = 2;
        ct4VM.IsFullYearReport = false;
        ct5VM.Yearlevel = 4;
        ct5VM.HalfYear = 1;
        ct5VM.IsFullYearReport = false;
        ct6VM.Yearlevel = 4;
        ct6VM.HalfYear = 2;
        ct6VM.IsFullYearReport = false;
    }

    public void CreateTeachers()
    {
        var dbh = new DbHelper();
        var t1 = new Teacher
        {
            FirstName = "Astrid",
            LastName = "Gerbracht",
            Gender = GenderValues.weiblich,
            IsHeadmaster = false,
            IsAdmin = true,
            Password = "Pappnase"
        };
        var t2 = new Teacher
        {
            FirstName = "Bettina",
            LastName = "Nebel",
            Gender = GenderValues.weiblich,
            IsHeadmaster = true,
            IsAdmin = false
        };
        var t3 = new Teacher
        {
            FirstName = "Caroline",
            LastName = "Schäfer",
            Gender = GenderValues.weiblich,
            IsHeadmaster = false,
            IsAdmin = false
        };
        var t4 = new Teacher
        {
            FirstName = "Herbert",
            LastName = "Böttcher",
            Gender = GenderValues.männlich,
            IsHeadmaster = false,
            IsAdmin = false
        };
        dbh.Save(t1);
        dbh.Save(t2);
        dbh.Save(t3);
        dbh.Save(t4);
    }

    public void CreateCertificateTemplatePages()
    {
        var dbh = new DbHelper();
        int max;

        List<CertificateTemplate> cts = new List<CertificateTemplate>();
        cts = dbh.LoadAll<CertificateTemplate>().OrderBy(ct => ct.Yearlevel).ThenBy(ct => ct.HalfYear).ToList();
        CertificateTemplatePage ctp;

        foreach (CertificateTemplate ct in cts)
        {
            if (ct.Yearlevel <= 3)
            {
                max = 4;
            }
            else
            {
                if (ct.HalfYear == 1)
                {
                    max = 3;
                }
                else
                {
                    max = 1;
                }
            }
            for (int i = 1; i <= max; i++)
            {
                ctp = new CertificateTemplatePage();
                ctp.CertificateTemplateId = ct.ID!;
                ctp.PageNumber = i;
                ct.CertificateTemplatePages.Add(ctp);
                dbh.Save(ctp);
            }
        }

    }
}
