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

namespace Esorb.Certificate.App;

public partial class MainWindow : Window
{
    //private ICertifcateViewModel certificateViewModel;
    public readonly ICertifcateViewModel certifcateViewModel;
    private IList<NavButton> navButtons = new List<NavButton>();

    //public ICertifcateViewModel CertificateViewModel
    //{
    //    get
    //    {
    //        return certificateViewModel;
    //    }
    //    private set
    //    {
    //        certificateViewModel = value;
    //    }
    //}
    public MainWindow(ICertifcateViewModel certifcateViewModel)
    {
        InitializeComponent();
        SetGuiIcons();
        AddNavButtons();
        WindowState = WindowState.Maximized;
        this.certifcateViewModel = certifcateViewModel;
        DataContext = this.certifcateViewModel;
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
    private void SetGuiIcons()
    {
        this.StartHeader.Text = char.ConvertFromUtf32(Convert.ToInt32("E80F", 16));
    }

    //private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    //{

    //}

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

    //private void GitHubButton_Click(object sender, RoutedEventArgs e)
    //{
    //    try
    //    {
    //        string url = "https://github.com/Esorb/Certificate";
    //        Process.Start(new ProcessStartInfo("cmd", $"/c start {url}"));
    //    }
    //    catch (System.ComponentModel.Win32Exception noBrowser)
    //    {
    //        if (noBrowser.ErrorCode == -2147467259)
    //            System.Windows.MessageBox.Show(noBrowser.Message);
    //    }
    //    catch (System.Exception other)
    //    {
    //        System.Windows.MessageBox.Show(other.Message);
    //    }
    //}

    private void BtnGetDatabasePath_Click(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.OpenFileDialog ofd = new()
        {
            Filter = "Zeugnisbasisdateien (*.db)|*.db",
            Multiselect = false,
            Title = "Zeugnisbasisdatei öffnen"
        };
        var result = ofd.ShowDialog();
        if (result is not null && result is true)
        {
            string databasePath = ofd.FileName;
            System.Windows.MessageBox.Show(databasePath);
        }
    }

    private void BtnGetOutputPath_Click(object sender, RoutedEventArgs e)
    {
        FolderBrowserDialog folderBrowserDialog = new();
        folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //folderBrowserDialog.SelectedPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "OneDrive", "Documents");
        var result = folderBrowserDialog.ShowDialog();
        if (result == System.Windows.Forms.DialogResult.OK)
        {
            string path = folderBrowserDialog.SelectedPath;
            System.Windows.MessageBox.Show(path);
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
            AppFrame.Navigate(ClickedNavButton.NavUri);
            ClickedNavButton.Selected = true;
        }


    }
}
