using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using Esorb.Certificate.App.ViewModel;

namespace Esorb.Certificate.App;

public partial class MainWindow : Window
{
    private readonly ICertificateSettingsViewModel certificateSettingsViewModel;

    public MainWindow(ICertificateSettingsViewModel certificateSettingsViewModel)
    {
        DataContext = new CertificateViewModell();
        InitializeComponent();
        SetGuiIcons();
        this.WindowState = WindowState.Maximized;
        this.certificateSettingsViewModel = certificateSettingsViewModel;
        //this.Loaded += MainWindow_Loaded;
    }

    private void SetGuiIcons()
    {
        this.CloseButton.Content = char.ConvertFromUtf32(Convert.ToInt32("E711", 16));
        this.MinimizeButton.Content = char.ConvertFromUtf32(Convert.ToInt32("E921", 16));
        this.StartHeader.Text = char.ConvertFromUtf32(Convert.ToInt32("E80F", 16));
        this.InputHeader.Text = char.ConvertFromUtf32(Convert.ToInt32("E70F", 16));
        this.ExportHeader.Text = char.ConvertFromUtf32(Convert.ToInt32("F571", 16));
        this.AdminHeader.Text = char.ConvertFromUtf32(Convert.ToInt32("E15E", 16));
        this.TemplateHeader.Text = char.ConvertFromUtf32(Convert.ToInt32("E713", 16));
        this.CertificateHeader.Text = char.ConvertFromUtf32(Convert.ToInt32("F56E", 16));
        this.TeacherHeader.Text = char.ConvertFromUtf32(Convert.ToInt32("E77B", 16));
        this.DistributionHeader.Text = char.ConvertFromUtf32(Convert.ToInt32("E792", 16));
        this.PupilHeader.Text = char.ConvertFromUtf32(Convert.ToInt32("ECA7", 16));
        this.ClassHeader.Text = char.ConvertFromUtf32(Convert.ToInt32("EBDA", 16));
        this.InfoHeader.Text = char.ConvertFromUtf32(Convert.ToInt32("E946", 16));
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
                MessageBox.Show(noBrowser.Message);
        }
        catch (System.Exception other)
        {
            MessageBox.Show(other.Message);
        }
    }

    private void BtnGetDatabasePath_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Test");
    }

    private void BtnGetOutputPath_Click(object sender, RoutedEventArgs e)
    {

    }
}
