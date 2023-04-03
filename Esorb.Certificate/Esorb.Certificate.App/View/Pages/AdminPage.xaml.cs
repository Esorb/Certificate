using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

using Esorb.Certificate.App.ViewModel;
using Esorb.Certificate.App.View.Controls;


namespace Esorb.Certificate.App.View.Pages;

public partial class AdminPage : Page
{
    private IList<NavButton> navButtons = new List<NavButton>();
    private IDictionary<Uri, Page> subPages = new Dictionary<Uri, Page>();
    private ICertificateSettingsViewModel SettingsVM;

    public readonly ICertifcateViewModel certifcateViewModel;

    public AdminPage(ICertifcateViewModel certifcateViewModel)
    {
        InitializeComponent();
        this.certifcateViewModel = certifcateViewModel;
        DataContext = this.certifcateViewModel;

        AddNavButtons();
        InitSubPages();
        SetAdminStatus();
    }


    private void SetAdminStatus()
    {
        var btn = GetLastActivatedNavButton();
        btn.Selected = true;
        AdminFrame.Navigate(subPages[btn.NavUri!]);
    }


    private void InitSubPages()
    {
        subPages.Add(BtnTemplate.NavUri!, new TemplatePage(certifcateViewModel));
        subPages.Add(BtnCertificate.NavUri!, new CertificatePage(certifcateViewModel));
        subPages.Add(BtnTeacher.NavUri!, new TeacherPage(certifcateViewModel));
        subPages.Add(BtnSettings.NavUri!, new SettingsPage(certifcateViewModel));
        subPages.Add(BtnClass.NavUri!, new SchoolClassPage(certifcateViewModel));
        subPages.Add(BtnDistribution.NavUri!, new DistributionPage(certifcateViewModel));
    }

    private void AddNavButtons()
    {
        navButtons.Add(BtnSettings);
        navButtons.Add(BtnTemplate);
        navButtons.Add(BtnCertificate);
        navButtons.Add(BtnTeacher);
        navButtons.Add(BtnClass);
        navButtons.Add(BtnDistribution);
    }

    private void AdminPanel_Click(object sender, RoutedEventArgs e)
    {
        var ClickedNavButton = e.OriginalSource as NavButton;
        if (ClickedNavButton!.NavUri != null)
        {
            foreach (var navBtn in navButtons)
            {
                navBtn.Selected = false;
            }

            AdminFrame.Navigate(subPages[ClickedNavButton.NavUri]);
            ClickedNavButton.Selected = true;
        }
    }

    private void SetLastActivatedNavButton(NavButton btn)
    {
        if (btn == BtnSettings) { SettingsVM.SubPage = "Settings"; }
        else if (btn == BtnTemplate) { SettingsVM.SubPage = "Template"; }
        else if (btn == BtnCertificate) { SettingsVM.SubPage = "Certificate"; }
        else if (btn == BtnTeacher) { SettingsVM.SubPage = "Teacher"; }
        else if (btn == BtnClass) { SettingsVM.SubPage = "Class"; }
        else if (btn == BtnDistribution) { SettingsVM.SubPage = "Distribution"; }
        else { SettingsVM.SubPage = "Settings"; }
    }


    private NavButton GetLastActivatedNavButton()
    {
        NavButton btn;

        switch (certifcateViewModel.CertificateSettingsViewModel.SubPage)
        {
            case "Settings":
                return BtnSettings;
            case "Template":
                return BtnTemplate;
            case "Certificate":
                return BtnCertificate;
            case "Teacher":
                return BtnTeacher;
            case "Class":
                return BtnClass;
            case "Distribution":
                return BtnDistribution;
            default:
                return BtnSettings;
        }
    }
}
