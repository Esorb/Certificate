using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using Esorb.Certificate.App.ViewModel;
using Esorb.Certificate.App.View.Controls;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using Esorb.Certificate.App.Database;
using System.Windows.Controls;
using Esorb.Certificate.App.View.Pages;

namespace Esorb.Certificate.App;

public partial class MainWindow : Window
{
    public readonly ICertifcateViewModel certifcateViewModel;
    private IList<NavButton> navButtons = new List<NavButton>();
    private IDictionary<Uri, Page> pages = new Dictionary<Uri, Page>();
    public MainWindow(ICertifcateViewModel certifcateViewModel)
    {
        InitializeComponent();
        AddNavButtons();
        WindowState = WindowState.Maximized;
        InitPages();
        SetApplicationStatus();
        this.certifcateViewModel = certifcateViewModel;
        DataContext = this.certifcateViewModel;
    }

    private void SetApplicationStatus()
    {
    }

    private void InitPages()
    {
        pages.Add(BtnStart.NavUri!, new StartPage());
        pages.Add(BtnInput.NavUri!, new InputPage());
        pages.Add(BtnExport.NavUri!, new ExportPage());
        pages.Add(BtnAdmin.NavUri!, new AdminPage());
        pages.Add(BtnInfo.NavUri!, new InfoPage());
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
        }
        else
        {
            NavColumn.Width = bigGridLength;
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
        }


    }
}
