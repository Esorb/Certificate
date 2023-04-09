using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.Model;
using static System.Net.WebRequestMethods;

namespace Esorb.Certificate.App.ViewModel
{
    public partial class CertificateTemplateViewModel : ObservableObject
    {
        private CertificateTemplate certificateTemplate;
        private DbHelper dbHelper;

        public CertificateTemplateViewModel(CertificateTemplate certificateTemplate, DbHelper dbHelper)
        {
            this.certificateTemplate = certificateTemplate;
            this.dbHelper = dbHelper;
            AddCertificateTemplatePage = new RelayCommand(ExecuteAddCertificateTemplatePage, CanExecuteAddCertificateTemplatePage);
            RemoveCertificateTemplatePage = new RelayCommand(ExecuteRemoveCertificateTemplatePage, CanExecuteRemoveCertificateTemplatePage);
        }
        public RelayCommand AddCertificateTemplatePage { get; private set; }
        public RelayCommand RemoveCertificateTemplatePage { get; private set; }


        public int HalfYear
        {
            get => certificateTemplate.HalfYear;
            set
            {
                if (value != certificateTemplate.HalfYear)
                {
                    certificateTemplate.HalfYear = value;
                    OnPropertyChanged();
                    dbHelper.Save(certificateTemplate);
                }
            }
        }

        public int Yearlevel
        {
            get => certificateTemplate.Yearlevel;
            set
            {
                if (value != certificateTemplate.Yearlevel)
                {
                    certificateTemplate.Yearlevel = value;
                    OnPropertyChanged();
                    dbHelper.Save(certificateTemplate);
                }
            }
        }

        public bool IsFullYearReport
        {
            get => certificateTemplate.IsFullYearReport;
            set
            {
                if (value != certificateTemplate.IsFullYearReport)
                {
                    certificateTemplate.IsFullYearReport = value;
                    HalfYear = 2;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Yearlevel));
                    dbHelper.Save(certificateTemplate);
                }
            }
        }

        public string TemplateName
        {
            get
            {
                if (IsFullYearReport)
                {
                    return $"Vorlage für das {Yearlevel}. Schuljahr";
                }
                else
                {
                    return $"Vorlage für das {Yearlevel}. Schuljahr - {HalfYear}. Halbjahr";
                }
            }
        }

        public void Delete()
        {
            dbHelper.Delete(certificateTemplate);
        }

        public ObservableCollection<CertificateTemplatePageViewModel> CertificateTemplatePages { get; set; } = new ObservableCollection<CertificateTemplatePageViewModel>();

        private void ExecuteAddCertificateTemplatePage()
        {
            var ctp = new CertificateTemplatePage();
            ctp.CertificateTemplateId = certificateTemplate.ID!;
            ctp.PageNumber = CertificateTemplatePages.Count + 1;
            certificateTemplate.CertificateTemplatePages.Add(ctp);
            CertificateTemplatePages.Add(new CertificateTemplatePageViewModel(ctp, dbHelper));
            dbHelper.Save(ctp);
        }
        private bool CanExecuteAddCertificateTemplatePage()
        {
            return true;
        }

        private void ExecuteRemoveCertificateTemplatePage()
        {
            MessageBox.Show("Remove");
        }
        private bool CanExecuteRemoveCertificateTemplatePage()
        {
            return true;
        }
    }
}
