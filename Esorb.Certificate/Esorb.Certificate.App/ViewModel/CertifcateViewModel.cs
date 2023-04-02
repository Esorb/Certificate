using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esorb.Certificate.App.Model;

namespace Esorb.Certificate.App.ViewModel
{
    public class CertifcateViewModel : ObservableObject, ICertifcateViewModel
    {

        public CertifcateViewModel(ICertificateModel certificateModel)
        {
        }

        private ICertificateSettingsViewModel certificateSettingsViewModel = new CertificateSettingsViewModel();
        private ICertificateDataViewModel certificateDateViewModel;
        private IList<TeacherViewModel> teachersViewModel;
        private IList<PupilViewModel> pupilsViewModel;
        private ICertificateModel certificateModel;


        public IList<PupilViewModel> PupilsViewModel
        {
            get { return pupilsViewModel; }
            set { pupilsViewModel = value; }
        }


        public IList<TeacherViewModel> TeachersViewModel
        {
            get { return teachersViewModel; }
            set { teachersViewModel = value; }
        }

        public ICertificateSettingsViewModel CertificateSettingsViewModel
        {
            get { return certificateSettingsViewModel; }
            set { certificateSettingsViewModel = value; }
        }

        public ICertificateDataViewModel CertificateDateViewModel
        {
            get { return certificateDateViewModel; }
            set { certificateDateViewModel = value; }
        }

    }
}
