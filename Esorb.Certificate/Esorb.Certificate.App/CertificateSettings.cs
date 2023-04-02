using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App
{
    public class CertificateSettings : ICertificateSettings
    {
        public CertificateSettings()
        {
            databasePath = Properties.Settings.Default.DatabasePath;
            schoolClass = Properties.Settings.Default.SchoolClass;
            schoolYear = Properties.Settings.Default.SchoolYear;
            halfYear = Properties.Settings.Default.HalfYear;
            teacher = Properties.Settings.Default.Teacher;
            outputFolder = Properties.Settings.Default.OutputFolder;
            page = Properties.Settings.Default.Page;
            subPage = Properties.Settings.Default.SubPage;
            menuPosition = Properties.Settings.Default.MenuPosition;
        }

        private string schoolYear;
        private string halfYear;
        private string schoolClass;
        private string databasePath;
        private string outputFolder;
        private string page;
        private string subPage;
        private string teacher;
        private string menuPosition;

        public string MenuPosition
        {
            get { return menuPosition; }
            set { menuPosition = value; }
        }

        public string SubPage
        {
            get { return subPage; }
            set { subPage = value; }
        }
        public string Page
        {
            get { return page; }
            set { page = value; }
        }
        public string OutPutFolder
        {
            get { return outputFolder; }
            set { outputFolder = value; }
        }
        public string DatabasePath
        {
            get => databasePath;
            set { databasePath = value; }
        }
        public string SchoolClass
        {
            get => schoolClass;
            set { schoolClass = value; }
        }
        public string SchoolYear
        {
            get => schoolYear;
            set { schoolYear = value; }
        }
        public string HalfYear
        {
            get => halfYear;
            set { halfYear = value; }
        }
        public string Teacher
        {
            get => teacher;
            set { teacher = value; }
        }
        public void Save()
        {
            Properties.Settings.Default.DatabasePath = databasePath;
            Properties.Settings.Default.SchoolClass = schoolClass;
            Properties.Settings.Default.SchoolYear = schoolYear;
            Properties.Settings.Default.HalfYear = halfYear;
            Properties.Settings.Default.Teacher = teacher;
            Properties.Settings.Default.OutputFolder = outputFolder;
            Properties.Settings.Default.Page = page;
            Properties.Settings.Default.SubPage = subPage;
            Properties.Settings.Default.MenuPosition = menuPosition;
            Properties.Settings.Default.Save();
        }
    }
}
