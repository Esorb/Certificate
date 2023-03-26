using System.Collections.Generic;
using Esorb.Certificate.App.Database;
using System.Linq;

namespace Esorb.Certificate.App.Model
{
    public class CertificateModel
    {
        private DbHelper dbHelper;

        public DbHelper DbHelper
        {
            get { return dbHelper; }
            set { dbHelper = value; }
        }

        public IList<Teacher> Teachers { get; private set; } = new List<Teacher>();
        public IList<Pupil> Pupils { get; private set; } = new List<Pupil>();
        public IList<SchoolClass> SchoolClasses { get; private set; } = new List<SchoolClass>();
        public IList<CertificateTemplate> CertificateTemplates { get; private set; } = new List<CertificateTemplate>();
        public CertificateData CertificateData { get; private set; } = new();

        public void LoadCertificateModel()
        {
            Teachers = DbHelper.LoadAll<Teacher>().OrderBy(teacher => teacher.FullName).ToList();
            Pupils = DbHelper.LoadAll<Pupil>().OrderBy(pupil => pupil.FullName).ToList();
            SchoolClasses = DbHelper.LoadAll<SchoolClass>().OrderBy(schoolClass => schoolClass.ClassName).ToList();
        }
    }
}
