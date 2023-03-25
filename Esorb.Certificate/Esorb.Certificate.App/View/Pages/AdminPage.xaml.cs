using System;
using System.Collections.Generic;
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
    /// Interaktionslogik für AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
            SetGuiIcons();
        }

        private void SetGuiIcons()
        {
            BtnTemplate.NavIcon = char.ConvertFromUtf32(Convert.ToInt32("E713", 16));
            BtnCertificate.NavIcon = char.ConvertFromUtf32(Convert.ToInt32("F56E", 16));

        }
    }
}
