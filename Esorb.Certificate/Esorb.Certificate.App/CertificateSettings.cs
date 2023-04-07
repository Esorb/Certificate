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
            DatabasePath = Properties.Settings.Default.DatabasePath;
            SchoolClass = Properties.Settings.Default.SchoolClass;
            SchoolYear = Properties.Settings.Default.SchoolYear;
            HalfYear = Properties.Settings.Default.HalfYear;
            Teacher = Properties.Settings.Default.Teacher;
            OutputFolder = Properties.Settings.Default.OutputFolder;
            Page = Properties.Settings.Default.Page;
            SubPage = Properties.Settings.Default.SubPage;
            MenuPosition = Properties.Settings.Default.MenuPosition;
            TeacherGUID = Properties.Settings.Default.TeacherGUID;
            SchoolClassGUID = Properties.Settings.Default.SchoolClassGUID;
        }
        public string MenuPosition { get; set; }
        public string SubPage { get; set; }
        public string Page { get; set; }
        public string OutputFolder { get; set; }
        public string DatabasePath { get; set; }
        public string SchoolClass { get; set; }
        public string SchoolYear { get; set; }
        public string HalfYear { get; set; }
        public string Teacher { get; set; }
        public string TeacherGUID { get; set; }
        public string SchoolClassGUID { get; set; }

        public void Save()
        {
            Properties.Settings.Default.DatabasePath = DatabasePath;
            Properties.Settings.Default.SchoolClass = SchoolClass;
            Properties.Settings.Default.SchoolYear = SchoolYear;
            Properties.Settings.Default.HalfYear = HalfYear;
            Properties.Settings.Default.Teacher = Teacher;
            Properties.Settings.Default.OutputFolder = OutputFolder;
            Properties.Settings.Default.Page = Page;
            Properties.Settings.Default.SubPage = SubPage;
            Properties.Settings.Default.MenuPosition = MenuPosition;
            Properties.Settings.Default.TeacherGUID = TeacherGUID;
            Properties.Settings.Default.SchoolClassGUID = SchoolClassGUID;
            Properties.Settings.Default.Save();
        }
    }
}
