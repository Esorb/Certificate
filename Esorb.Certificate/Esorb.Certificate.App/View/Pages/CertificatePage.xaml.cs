using CsvHelper;
using Esorb.Certificate.App.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaktionslogik für CertificatePage.xaml
    /// </summary>
    public partial class CertificatePage : Page
    {
        public readonly CertificateDataViewModel CertifcateDataViewModel;
        public CertificatePage(CertificateDataViewModel certifcateDataViewModel)
        {
            InitializeComponent();
            CertifcateDataViewModel = certifcateDataViewModel;
            DataContext = CertifcateDataViewModel;
            Prepare();
        }
        private void Prepare()
        {
            CertifcateDataViewModel.SchoolYearChoices.ForEach(sy => CbSchoolYear.Items.Add(sy));
            CertifcateDataViewModel.HalfYearChoices.ForEach(hy => CbHalfYear.Items.Add(hy));
        }
    }
}
