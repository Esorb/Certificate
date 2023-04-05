using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.Model;

namespace Esorb.Certificate.App.ViewModel
{
    public class CertificateTemplateViewModel : ObservableObject
    {
        private CertificateTemplate _certificateTemplate;
        private DbHelper _dbHelper;

        public CertificateTemplateViewModel(CertificateTemplate certificateTemplate, DbHelper dbHelper)
        {
            _certificateTemplate = certificateTemplate;
            _dbHelper = dbHelper;
        }

        public int HalfYear
        {
            get => _certificateTemplate.HalfYear;
            set
            {
                if (value != _certificateTemplate.HalfYear)
                {
                    _certificateTemplate.HalfYear = value;
                    OnPropertyChanged();
                    _dbHelper.Save(_certificateTemplate);
                }
            }
        }

        public int Yearlevel
        {
            get => _certificateTemplate.Yearlevel;
            set
            {
                if (value != _certificateTemplate.Yearlevel)
                {
                    _certificateTemplate.Yearlevel = value;
                    OnPropertyChanged();
                    _dbHelper.Save(_certificateTemplate);
                }
            }
        }

        public bool IsFullYearReport
        {
            get => _certificateTemplate.IsFullYearReport;
            set
            {
                if (value != _certificateTemplate.IsFullYearReport)
                {
                    _certificateTemplate.IsFullYearReport = value;
                    HalfYear = 2;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Yearlevel));
                    _dbHelper.Save(_certificateTemplate);
                }
            }
        }

    }
}
