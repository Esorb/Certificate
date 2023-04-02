﻿using Esorb.Certificate.App.View.Controls;
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
using Esorb.Certificate.App.ViewModel;
using Esorb.Certificate.App.View.Controls;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;


namespace Esorb.Certificate.App.View.Pages
{
    public partial class AdminPage : Page
    {
        private IList<NavButton> navButtons = new List<NavButton>();
        private IDictionary<Uri, Page> subPages = new Dictionary<Uri, Page>();
        public readonly ICertifcateViewModel certifcateViewModel;

        public AdminPage(ICertifcateViewModel certifcateViewModel)
        {
            InitializeComponent();
            AddNavButtons();
            InitSubPages();
            this.certifcateViewModel = certifcateViewModel;
            DataContext = this.certifcateViewModel;
        }

        private void InitSubPages()
        {
            subPages.Add(BtnTemplate.NavUri!, new TemplatePage(certifcateViewModel));
            subPages.Add(BtnCertificate.NavUri!, new CertificatePage(certifcateViewModel));
            subPages.Add(BtnTeacher.NavUri!, new TeacherPage(certifcateViewModel));
            subPages.Add(BtnPupil.NavUri!, new PupilPage(certifcateViewModel));
            subPages.Add(BtnClass.NavUri!, new SchoolClassPage(certifcateViewModel));
            subPages.Add(BtnDistribution.NavUri!, new DistributionPage(certifcateViewModel));
        }

        private void AddNavButtons()
        {
            navButtons.Add(BtnTemplate);
            navButtons.Add(BtnCertificate);
            navButtons.Add(BtnTeacher);
            navButtons.Add(BtnPupil);
            navButtons.Add(BtnClass);
            navButtons.Add(BtnDistribution);
        }

        private void AdminPanel_Click(object sender, RoutedEventArgs e)
        {
            var ClickedNavButton = e.OriginalSource as NavButton;
            if (ClickedNavButton!.NavUri != null)
            {
                foreach (var navBtn in navButtons)
                {
                    navBtn.Selected = false;
                }

                AdminFrame.Navigate(subPages[ClickedNavButton.NavUri]);
                ClickedNavButton.Selected = true;
            }
        }
    }
}
