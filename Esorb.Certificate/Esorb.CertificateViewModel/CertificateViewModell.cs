using Esorb.Certificate.Basics;
using Esorb.Certificate.Model;
using Esorb.School_Certificate.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.ViewModel
{
    public class CertificateViewModell : ViewModelBase
    {
        private CertificateData certificateData = new();

        public CertificateData CertificateData
        {
            get
            {
                return certificateData;
            }
            set
            {
                certificateData = value;
                OnPropertyChanged(nameof(certificateData));
            }
        }

        private ObservableCollection<SchoolClass> schoolClasses = new();

        public ObservableCollection<SchoolClass> SchoolClasses
        {
            get
            {
                return schoolClasses;
            }
            set
            {
                schoolClasses = value;
            }
        }


    }
}
