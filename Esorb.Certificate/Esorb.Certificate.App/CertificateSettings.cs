using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.App
{
    public class CertificateSettings
    {
        public CertificateSettings()
        {
            databasePath = Properties.Settings.Default.DatabasePath;
            schoolClass = Properties.Settings.Default.SchoolClass;
            schoolYear = Properties.Settings.Default.SchoolYear;
            halfYear = Properties.Settings.Default.HalfYear;
            teacher = Properties.Settings.Default.Teacher;
            outputFolder = Properties.Settings.Default.OutputFolder;
        }

        private string outputFolder;

        public string OutPutFolder
        {
            get { return outputFolder; }
            set { outputFolder = value; }
        }

        private string databasePath;
        public string DatabasePath
        {
            get => databasePath;
            set { databasePath = value; }
        }
        private string schoolClass;
        public string SchoolClass
        {
            get => schoolClass;
            set { schoolClass = value; }
        }
        private string schoolYear;
        public string SchoolYear
        {
            get => schoolYear;
            set { schoolYear = value; }
        }
        private string halfYear;
        public string HalfYear
        {
            get => halfYear;
            set { halfYear = value; }
        }
        private string teacher;
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
            Properties.Settings.Default.Save();
        }
    }
}
