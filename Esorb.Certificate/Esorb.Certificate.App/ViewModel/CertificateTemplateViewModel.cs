using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.Model;
using static System.Net.WebRequestMethods;

namespace Esorb.Certificate.App.ViewModel
{
    public partial class CertificateTemplateViewModel : ObservableObject
    {
        private readonly CertificateTemplate certificateTemplate;
        private DbHelper dbHelper;

        public CertificateTemplateViewModel(CertificateTemplate certificateTemplate)
        {
            this.certificateTemplate = certificateTemplate;
            dbHelper = DbHelper.GetInstance();
            AddCertificateTemplatePage = new RelayCommand(ExecuteAddCertificateTemplatePage, CanExecuteAddCertificateTemplatePage);
        }
        public RelayCommand AddCertificateTemplatePage { get; private set; }

        public void RemoveCertificateTemplatePage(CertificateTemplatePageViewModel PageToBeRemoved)
        {
            certificateTemplate.CertificateTemplatePages.Remove(PageToBeRemoved.CertificateTemplatePage);
            dbHelper.Delete(PageToBeRemoved.CertificateTemplatePage);
            CertificateTemplatePages.Remove(PageToBeRemoved);
            for (int i = 0; i < CertificateTemplatePages.Count; i++)
            {
                CertificateTemplatePages[i].PageNumber = i + 1;
            }
            OnPropertyChanged(nameof(CertificateTemplatePages));
            CommandManager.InvalidateRequerySuggested();
        }

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

        public string? AbbForFileName
        {
            get => certificateTemplate.AbbForFileName;
        }
        public string? TemplateName
        {
            get
            {
                if ((!string.IsNullOrEmpty(AbbForFileName)) && AbbForFileName.Equals("LFE"))
                {
                    return $"Vorlage für die Lern-Förder-Empfehlung";
                }
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
            CertificateTemplatePage ctp = new()
            {
                CertificateTemplateId = certificateTemplate.ID!,
                PageNumber = CertificateTemplatePages.Count + 1
            };
            certificateTemplate.CertificateTemplatePages.Add(ctp);
            CertificateTemplatePageViewModel ctpvm = new(ctp)
            {
                CertificateTemplateViewModel = this
            };
            CertificateTemplatePages.Add(ctpvm);
            dbHelper.Save(ctp);
        }

        public ObservableCollection<ContentViewModel> ContentViewModels { get; set; } = new();
        private bool CanExecuteAddCertificateTemplatePage()
        {
            return true;
        }
    }
}
