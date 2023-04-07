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
    public partial class CertificateSettingsViewModel : ObservableObject
    {
        private CertificateSettings certificateSettings = new();
        public CertificateSettingsViewModel()
        {
        }
        public string DatabasePath
        {
            get => certificateSettings.DatabasePath;
            set
            {
                if (certificateSettings.DatabasePath != value)
                {
                    certificateSettings.DatabasePath = value;
                    OnPropertyChanged();
                    certificateSettings.Save();
                }
            }
        }
        public string OutputFolder
        {
            get => certificateSettings.OutputFolder;
            set
            {
                if (certificateSettings.OutputFolder != value)
                {
                    certificateSettings.OutputFolder = value;
                    OnPropertyChanged();
                    certificateSettings.Save();
                }
            }
        }
        public string SchoolClass
        {
            get => certificateSettings.SchoolClass;
            set
            {
                if (certificateSettings.SchoolClass != value)
                {
                    certificateSettings.SchoolClass = value;
                    OnPropertyChanged();
                    certificateSettings.Save();
                }
            }
        }
        public string SchoolYear
        {
            get => certificateSettings.SchoolYear;
            set
            {
                if (certificateSettings.SchoolYear != value)
                {
                    certificateSettings.SchoolYear = value;
                    OnPropertyChanged();
                    certificateSettings.Save();
                }
            }
        }
        public string HalfYear
        {
            get => certificateSettings.HalfYear;
            set
            {
                if (certificateSettings.HalfYear != value)
                {
                    certificateSettings.HalfYear = value;
                    OnPropertyChanged();
                    certificateSettings.Save();
                }
            }
        }
        public string Teacher
        {
            get => certificateSettings.Teacher;
            set
            {
                if (certificateSettings.Teacher != value)
                {
                    certificateSettings.Teacher = value;
                    OnPropertyChanged();
                    certificateSettings.Save();
                }
            }
        }
        public string Page
        {
            get => certificateSettings.Page;
            set
            {
                if (certificateSettings.Page != value)
                {
                    certificateSettings.Page = value;
                    OnPropertyChanged();
                    certificateSettings.Save();
                }
            }
        }
        public string SubPage
        {
            get => certificateSettings.SubPage;
            set
            {
                if (certificateSettings.SubPage != value)
                {
                    certificateSettings.SubPage = value;
                    OnPropertyChanged();
                    certificateSettings.Save();
                }
            }
        }

        public string MenuPosition
        {
            get => certificateSettings.MenuPosition;
            set
            {
                if (certificateSettings.MenuPosition != value)
                {
                    certificateSettings.MenuPosition = value;
                    OnPropertyChanged();
                    certificateSettings.Save();
                }
            }
        }

        public string TeacherGUID
        {
            get => certificateSettings.TeacherGUID;
            set
            {
                if (certificateSettings.TeacherGUID != value)
                {
                    certificateSettings.TeacherGUID = value;
                    OnPropertyChanged();
                    certificateSettings.Save();
                }
            }
        }

        public string SchoolClassGUID
        {
            get => certificateSettings.SchoolClassGUID;
            set
            {
                if (certificateSettings.SchoolClassGUID != value)
                {
                    certificateSettings.SchoolClassGUID = value;
                    OnPropertyChanged();
                    certificateSettings.Save();
                }
            }
        }
    }
}
