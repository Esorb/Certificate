using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Windows.Controls;

using Esorb.Certificate.App.Model;
using Esorb.Certificate.App.ViewModel;
using Esorb.Certificate.App.View.Controls;
using Esorb.Certificate.App.View.Pages;

namespace Esorb.Certificate.App;

public partial class MainWindow : Window
{
    public readonly ICertificateModel certificateModel = new CertificateModel();
    public readonly ICertifcateViewModel certifcateViewModel;
    private ICertificateSettingsViewModel SettingsVM;
    private IList<NavButton> navButtons = new List<NavButton>();
    private IDictionary<Uri, Page> pages = new Dictionary<Uri, Page>();

    public MainWindow()
    {
        InitializeComponent();
        WindowState = WindowState.Maximized;
        certifcateViewModel = new CertifcateViewModel(certificateModel);
        SettingsVM = certifcateViewModel.CertificateSettingsViewModel;
        DataContext = this.certifcateViewModel;

        AddNavButtons();
        InitPages();
        InitMenu();
        SetApplicationStatus();
    }


    private void SetApplicationStatus()
    {
        var btn = GetLastActivatedNavButton();
        btn.Selected = true;
        AppFrame.Navigate(pages[btn.NavUri!]);
    }


    private GridLength GetLastMenuWidth()
    {
        GridLength result;

        switch (certifcateViewModel.CertificateSettingsViewModel.MenuPosition)
        {
            case "wide":
                return new GridLength(110, GridUnitType.Pixel);
            default:
                return new GridLength(44, GridUnitType.Pixel);
        }
    }


    private void InitPages()
    {
        pages.Add(BtnStart.NavUri!, new StartPage(certifcateViewModel));
        pages.Add(BtnInput.NavUri!, new InputPage(certifcateViewModel));
        pages.Add(BtnExport.NavUri!, new ExportPage(certifcateViewModel));
        pages.Add(BtnAdmin.NavUri!, new AdminPage(certifcateViewModel));
        pages.Add(BtnInfo.NavUri!, new InfoPage(certifcateViewModel));
    }


    private void InitMenu()
    {
        NavColumn.Width = GetLastMenuWidth();
    }


    private void AddNavButtons()
    {
        navButtons.Add(BtnMenue);
        navButtons.Add(BtnStart);
        navButtons.Add(BtnInput);
        navButtons.Add(BtnExport);
        navButtons.Add(BtnAdmin);
        navButtons.Add(BtnInfo);
    }


    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }


    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }


    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (this.WindowState == WindowState.Maximized)
        {
            var width = this.ActualWidth;
            var height = this.ActualHeight;
            this.Width = width - 2;
            this.Height = height - 2;
            this.Top = 1;
            this.Left = 1;

            this.WindowState = WindowState.Normal;
        }
        this.DragMove();
    }


    private void Border_MouseUp(object sender, MouseButtonEventArgs e)
    {
        if (this.WindowState == WindowState.Normal)
        {
            this.WindowState = WindowState.Maximized;
        }
    }


    private void BtnMenue_Click(object sender, RoutedEventArgs e)
    {
        GridLength smallGridLength = new GridLength(44, GridUnitType.Pixel);
        GridLength bigGridLength = new GridLength(110, GridUnitType.Pixel);
        if (NavColumn.Width.Equals(bigGridLength))
        {
            NavColumn.Width = smallGridLength;
            SettingsVM.MenuPosition = "narrow";
        }
        else
        {
            NavColumn.Width = bigGridLength;
            SettingsVM.MenuPosition = "wide";
        }
    }


    private void StackPanel_Click(object sender, RoutedEventArgs e)
    {

        var ClickedNavButton = e.OriginalSource as NavButton;
        if (ClickedNavButton.NavUri != null)
        {
            foreach (var navBtn in navButtons)
            {
                navBtn.Selected = false;
            }
            AppFrame.Navigate(pages[ClickedNavButton.NavUri]);
            ClickedNavButton.Selected = true;
            SetLastActivatedNavButton(ClickedNavButton);
        }
    }


    private void SetLastActivatedNavButton(NavButton btn)
    {
        if (btn == BtnStart) { SettingsVM.Page = "Start"; }
        else if (btn == BtnInput) { SettingsVM.Page = "Input"; }
        else if (btn == BtnExport) { SettingsVM.Page = "Export"; }
        else if (btn == BtnAdmin) { SettingsVM.Page = "Admin"; }
        else if (btn == BtnInfo) { SettingsVM.Page = "Info"; }
        else { SettingsVM.Page = "Start"; }
    }


    private NavButton GetLastActivatedNavButton()
    {
        NavButton btn;

        switch (certifcateViewModel.CertificateSettingsViewModel.Page)
        {
            case "Start":
                return BtnStart;
            case "Input":
                return BtnInput;
            case "Export":
                return BtnExport;
            case "Admin":
                return BtnAdmin;
            case "Info":
                return BtnInfo;
            default:
                return BtnStart;
        }
    }
}
