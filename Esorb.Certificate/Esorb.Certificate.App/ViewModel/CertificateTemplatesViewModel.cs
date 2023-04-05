﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Esorb.Certificate.App.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App.ViewModel
{
    public partial class CertificateTemplatesViewModel : ObservableObject, ICertificateTemplatesViewModel
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
        public ObservableCollection<CertificateTemplateViewModel> CertificateTemplates
        {
            get => certificateTemplates;
            set { certificateTemplates = value; }
        }


        private CertificateModel certificateModel;
        private ObservableCollection<CertificateTemplateViewModel> certificateTemplates;
        private CertificateTemplateViewModel selectedCertificateTemplate;

        private void BuildCertificateTemplatesViewModel()
        {
            certificateTemplates = new ObservableCollection<CertificateTemplateViewModel>();

            foreach (var ct in certificateModel.CertificateTemplates)
            {
                certificateTemplates.Add(new CertificateTemplateViewModel(ct, certificateModel.DbHelper));
            }
        }

        private void ExecuteAddCertificateTemplate()
        {
            CertificateTemplate certificateTemplate = new();
            CertificateTemplateViewModel certificateTemplateViewModel = new(certificateTemplate, certificateModel.DbHelper);
            CertificateTemplates.Add(certificateTemplateViewModel);
        }

        private bool CanExecuteAddCertificateTemplate()
        {
            return true;
        }

        private void ExecuteRemoveCertificateTemplate()
        {
            SelectedCertificateTemplate.Delete();
            CertificateTemplates.Remove(SelectedCertificateTemplate);
        }
        private bool CanExecuteRemoveCertificateTemplate()
        {
            return SelectedCertificateTemplate != null;
        }

    }
}