﻿using Esorb.Certificate.App.ViewModel;
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
    /// Interaktionslogik für SchoolClassPage.xaml
    /// </summary>
    public partial class SchoolClassPage : Page
    {
        public readonly ICertifcateViewModel certifcateViewModel;
        public SchoolClassPage(ICertifcateViewModel certifcateViewModel)
        {
            InitializeComponent();
            this.certifcateViewModel = certifcateViewModel;
            DataContext = this.certifcateViewModel;
        }
    }
}
