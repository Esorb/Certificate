using Esorb.Certificate.App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.ViewModel
{
    public class CertificateTemplatePagesViewModel
    {
        private CertificateModel certificateModel;
        public CertificateTemplatePagesViewModel(CertificateModel certificateModel)
        {
            this.certificateModel = certificateModel;
        }
        public ObservableCollection<CertificateTemplatePageViewModel> CertificateTemplatePages { get; private set; }
    }
}
