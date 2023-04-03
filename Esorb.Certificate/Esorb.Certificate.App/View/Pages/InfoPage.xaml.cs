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

namespace Esorb.Certificate.App.View.Pages
{
    /// <summary>
    /// Interaktionslogik für InfoPage.xaml
    /// </summary>
    public partial class InfoPage : Page
    {
        public readonly ICertifcateViewModel certifcateViewModel;

        public InfoPage(ICertifcateViewModel certifcateViewModel)
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
            MessageBox.Show("Test!");

            IList<GradeLimit> gradeLimits = new List<GradeLimit>();
            var gl1 = new GradeLimit { PercentageLimit = 0.965, Grade = "sehr gut", GradeNumeric = 1 };
            gradeLimits.Add(gl1);
            var gl2 = new GradeLimit { PercentageLimit = 0.845, Grade = "gut", GradeNumeric = 2 };
            gradeLimits.Add(gl2);
            var gl3 = new GradeLimit { PercentageLimit = 0.695, Grade = "befriediegend", GradeNumeric = 3 };
            gradeLimits.Add(gl3);
            var gl4 = new GradeLimit { PercentageLimit = 0.495, Grade = "ausreichend", GradeNumeric = 4 };
            gradeLimits.Add(gl4);
            var gl5 = new GradeLimit { PercentageLimit = 0.195, Grade = "mangelhaft", GradeNumeric = 5 };
            gradeLimits.Add(gl5);
            var gl6 = new GradeLimit { PercentageLimit = 0.0, Grade = "ungenügend", GradeNumeric = 6 };
            gradeLimits.Add(gl6);

            GradeCalculator gc = new GradeCalculator(gradeLimits);

            // Assert
            string erg = gc.Calculate(8, 8);
            erg = gc.Calculate(24, 23);

        }
    }
}
