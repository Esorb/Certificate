using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.ViewModel
{
    public class CertifcateViewModel : ObservableObject, ICertifcateViewModel
    {

        public CertifcateViewModel()
        {
            certificateSettingsViewModel = new CertificateSettingsViewModel();
        }

        private ICertificateSettingsViewModel certificateSettingsViewModel;

        public ICertificateSettingsViewModel CertificateSettingsViewModel
        {
            get { return certificateSettingsViewModel; }
            set { certificateSettingsViewModel = value; }
        }

    }
}
