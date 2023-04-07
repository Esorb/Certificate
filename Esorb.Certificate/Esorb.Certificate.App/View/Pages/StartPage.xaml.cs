using Esorb.Certificate.App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Esorb.Certificate.App.View.Pages;

public partial class StartPage : Page
{
    public readonly CertifcateViewModel certifcateViewModel;
    public StartPage(CertifcateViewModel certifcateViewModel)
    {
        InitializeComponent();
        this.certifcateViewModel = certifcateViewModel;
        DataContext = this.certifcateViewModel;
    }
    private void BtnGetOutputPath_Click(object sender, RoutedEventArgs e)
    {
        FolderBrowserDialog folderBrowserDialog = new()
        {
            SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        };
        //folderBrowserDialog.SelectedPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "OneDrive", "Documents");
        var result = folderBrowserDialog.ShowDialog();
        if (result == System.Windows.Forms.DialogResult.OK)
        {
            string path = folderBrowserDialog.SelectedPath;
            System.Windows.MessageBox.Show(path);
        }
    }
}
