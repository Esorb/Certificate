using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.ViewModel
{
    public partial class CertificateTemplatesViewModel : ObservableObject
    {
        public CertificateTemplatesViewModel(CertificateModel certificateModel)
        {
            this.certificateModel = certificateModel;
            BuildCertificateTemplatesViewModel();
            AddCertificateTemplate = new RelayCommand(ExecuteAddCertificateTemplate, CanExecuteAddCertificateTemplate);
            RemoveCertificateTemplate = new RelayCommand(ExecuteRemoveCertificateTemplate, CanExecuteRemoveCertificateTemplate);
        }

        public RelayCommand AddCertificateTemplate { get; private set; }
        public RelayCommand RemoveCertificateTemplate { get; private set; }

        public CertificateTemplateViewModel SelectedCertificateTemplate
        {
            get { return selectedCertificateTemplate; }
            set
            {
                selectedCertificateTemplate = value;
                OnPropertyChanged(nameof(selectedCertificateTemplate));
                RemoveCertificateTemplate.NotifyCanExecuteChanged();
            }
        }
        public ObservableCollection<CertificateTemplateViewModel> CertificateTemplateViewModels { get; private set; }

        private CertificateModel certificateModel;
        private CertificateTemplateViewModel selectedCertificateTemplate;

        private void BuildCertificateTemplatesViewModel()
        {
            CertificateTemplateViewModel ctvm;
            CertificateTemplatePageViewModel ctpvm;

            CertificateTemplateViewModels = new ObservableCollection<CertificateTemplateViewModel>();

            foreach (var ct in certificateModel.CertificateTemplates)
            {
                ctvm = new CertificateTemplateViewModel(ct, certificateModel.DbHelper);
                CertificateTemplateViewModels.Add(ctvm);

                foreach (var ctp in ct.CertificateTemplatePages)
                {
                    ctpvm = new CertificateTemplatePageViewModel(ctp, certificateModel.DbHelper);
                    ctvm.CertificateTemplatePages.Add(ctpvm);
                    ctpvm.CertificateTemplateViewModel = ctvm;
                }
            }
        }

        private void ExecuteAddCertificateTemplate()
        {
            CertificateTemplate certificateTemplate = new();
            CertificateTemplateViewModel certificateTemplateViewModel = new(certificateTemplate, certificateModel.DbHelper);
            CertificateTemplateViewModels.Add(certificateTemplateViewModel);
        }

        private bool CanExecuteAddCertificateTemplate()
        {
            return true;
        }

        private void ExecuteRemoveCertificateTemplate()
        {
            SelectedCertificateTemplate.Delete();
            CertificateTemplateViewModels.Remove(SelectedCertificateTemplate);
        }
        private bool CanExecuteRemoveCertificateTemplate()
        {
            return SelectedCertificateTemplate != null;
        }

    }
}
