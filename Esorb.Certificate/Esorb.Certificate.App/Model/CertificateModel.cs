using System.Collections.Generic;
using Esorb.Certificate.App.Database;
using System.Linq;

namespace Esorb.Certificate.App.Model
{
    public class CertificateModel
    {
        public DbHelper DbHelper { get; private set; } = new DbHelper();
        private CertificateSettings settings = new();
        public IList<Teacher> Teachers { get; private set; } = new List<Teacher>();
        public IList<Pupil> Pupils { get; private set; } = new List<Pupil>();
        public IList<SchoolClass> SchoolClasses { get; private set; } = new List<SchoolClass>();
        public IList<GradeLimit> GradeLimits { get; private set; } = new List<GradeLimit>();
        public IList<CertificateTemplate> CertificateTemplates { get; private set; } = new List<CertificateTemplate>();
        public CertificateData CertificateData { get; private set; } = new CertificateData();

        public CertificateModel()
        {
            if (DbHelper.IsCertificateFile(settings.DatabasePath))
            {
                LoadCertificateModel();
                LinkCertificateModel();
            }
        }
        public void LoadCertificateModel()
        {
            settings = new CertificateSettings();

            Teachers = DbHelper.LoadAll<Teacher>().OrderBy(teacher => teacher.FullName).ToList();
            Pupils = DbHelper.LoadAll<Pupil>().OrderBy(pupil => pupil.FullName).ToList();
            SchoolClasses = DbHelper.LoadAll<SchoolClass>().OrderBy(schoolClass => schoolClass.ClassName).ToList();
            GradeLimits = DbHelper.LoadAll<GradeLimit>().OrderBy(gl => gl.GradeNumeric).ToList();
            CertificateTemplates = DbHelper.LoadAll<CertificateTemplate>().OrderBy(ct => ct.Yearlevel).ThenBy(ct => ct.HalfYear).ToList();
            CertificateData = DbHelper.LoadAll<CertificateData>().ToList().FirstOrDefault();
        }

        public void ClearCertificateModel()
        {
            settings = new CertificateSettings();

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
