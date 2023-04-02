using System.Collections.Generic;
using Esorb.Certificate.App.Database;
using System.Linq;

namespace Esorb.Certificate.App.Model
{
    public class CertificateModel : ICertificateModel
    {
        private IDbHelper dbHelper = new DbHelper();
        public IList<Teacher> Teachers { get; private set; } = new List<Teacher>();
        public IList<Pupil> Pupils { get; private set; } = new List<Pupil>();
        public IList<SchoolClass> SchoolClasses { get; private set; } = new List<SchoolClass>();
        public IList<CertificateTemplate> CertificateTemplates { get; private set; } = new List<CertificateTemplate>();
        public ICertificateData CertificateData { get; private set; } = new CertificateData();

        public void LoadCertificateModel()
        {
            Teachers = dbHelper.LoadAll<Teacher>().OrderBy(teacher => teacher.FullName).ToList();
            Pupils = dbHelper.LoadAll<Pupil>().OrderBy(pupil => pupil.FullName).ToList();
            SchoolClasses = dbHelper.LoadAll<SchoolClass>().OrderBy(schoolClass => schoolClass.ClassName).ToList();
        }

        public void LinkCertificateModel()
        {
            LinkPupilsSchoolClasses();
        }

        private void LinkPupilsSchoolClasses()
        {
            foreach (var pupil in Pupils)
            {
                pupil.SchoolClass = SchoolClasses.FirstOrDefault(sc => sc.ID == pupil.SchoolClassId);
                pupil.SchoolClass?.Pupils.Add(pupil);
            }
        }
    }
}
