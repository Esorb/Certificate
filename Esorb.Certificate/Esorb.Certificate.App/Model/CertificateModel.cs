using System.Collections.Generic;
using Esorb.Certificate.App.Database;
using System.Linq;

namespace Esorb.Certificate.App.Model
{
    public class CertificateModel : ICertificateModel, ICertificateModel
    {
        private IDbHelper dbHelper = new DbHelper();
        private CertificateSettings settings = new();
        public IList<Teacher> Teachers { get; private set; } = new List<Teacher>();
        public IList<Pupil> Pupils { get; private set; } = new List<Pupil>();
        public IList<SchoolClass> SchoolClasses { get; private set; } = new List<SchoolClass>();
        public IList<GradeLimit> GradeLimits { get; private set; } = new List<GradeLimit>();
        public IList<CertificateTemplate> CertificateTemplates { get; private set; } = new List<CertificateTemplate>();
        public ICertificateData CertificateData { get; private set; } = new CertificateData();

        public CertificateModel()
        {
            if (dbHelper.IsSQLiteFile(settings.DatabasePath))
            {
                LoadCertificateModel();
            }
        }
        public void LoadCertificateModel()
        {
            Teachers = dbHelper.LoadAll<Teacher>().OrderBy(teacher => teacher.FullName).ToList();
            Pupils = dbHelper.LoadAll<Pupil>().OrderBy(pupil => pupil.FullName).ToList();
            SchoolClasses = dbHelper.LoadAll<SchoolClass>().OrderBy(schoolClass => schoolClass.ClassName).ToList();
            GradeLimits = dbHelper.LoadAll<GradeLimit>().OrderBy(gl => gl.GradeNumeric).ToList();
            CertificateTemplates = dbHelper.LoadAll<CertificateTemplate>().OrderBy(ct => ct.Yearlevel).ThenBy(ct => ct.HalfYear).ToList();
            CertificateData = dbHelper.LoadAll<CertificateData>().ToList().FirstOrDefault();
        }

        public void ClearCertificateModel()
        {
            Teachers.Clear();
            Pupils.Clear();
            SchoolClasses.Clear();
            GradeLimits.Clear();
            CertificateTemplates.Clear();
            CertificateData = new CertificateData();
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
