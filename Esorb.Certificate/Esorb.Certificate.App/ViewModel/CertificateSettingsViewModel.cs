using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Esorb.Certificate.App.ViewModel
{
    public partial class CertificateSettingsViewModel : ObservableObject, ICertificateSettingsViewModel
    {
        private CertificateSettings _certificateSettings = new CertificateSettings();
        public CertificateSettingsViewModel()
        {
        }
        public string DatabasePath
        {
            get => _certificateSettings.DatabasePath;
            set
            {
                if (_certificateSettings.DatabasePath != value)
                {
                    _certificateSettings.DatabasePath = value;
                    OnPropertyChanged();
                    _certificateSettings.Save();
                }
            }
        }
        public string SchoolClass
        {
            get => _certificateSettings.SchoolClass;
            set
            {
                if (_certificateSettings.SchoolClass != value)
                {
                    _certificateSettings.SchoolClass = value;
                    OnPropertyChanged();
                    _certificateSettings.Save();
                }
            }
        }
        public string SchoolYear
        {
            get => _certificateSettings.SchoolYear;
            set
            {
                if (_certificateSettings.SchoolYear != value)
                {
                    _certificateSettings.SchoolYear = value;
                    OnPropertyChanged();
                    _certificateSettings.Save();
                }
            }
        }
        public string HalfYear
        {
            get => _certificateSettings.HalfYear;
            set
            {
                if (_certificateSettings.HalfYear != value)
                {
                    _certificateSettings.HalfYear = value;
                    OnPropertyChanged();
                    _certificateSettings.Save();
                }
            }
        }
        public string Teacher
        {
            get => _certificateSettings.Teacher;
            set
            {
                if (_certificateSettings.Teacher != value)
                {
                    _certificateSettings.Teacher = value;
                    OnPropertyChanged();
                    _certificateSettings.Save();
                }
            }
        }
        public string Page
        {
            get => _certificateSettings.Page;
            set
            {
                if (_certificateSettings.Page != value)
                {
                    _certificateSettings.Page = value;
                    OnPropertyChanged();
                    _certificateSettings.Save();
                }
            }
        }
        public string SubPage
        {
            get => _certificateSettings.SubPage;
            set
            {
                if (_certificateSettings.SubPage != value)
                {
                    _certificateSettings.SubPage = value;
                    OnPropertyChanged();
                    _certificateSettings.Save();
                }
            }
        }

        public string MenuPosition
        {
            get => _certificateSettings.MenuPosition;
            set
            {
                if (_certificateSettings.MenuPosition != value)
                {
                    _certificateSettings.MenuPosition = value;
                    OnPropertyChanged();
                    _certificateSettings.Save();
                }
            }
        }
    }
}
