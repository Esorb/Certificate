using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Esorb.Certificate.App.View.Pages
{
    /// <summary>
    /// Interaktionslogik für InfoPage.xaml
    /// </summary>
    public partial class InfoPage : Page
    {
        public InfoPage()
        {
            InitializeComponent();
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


    }
}
