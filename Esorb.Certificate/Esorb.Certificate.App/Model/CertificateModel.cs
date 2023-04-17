using System.Collections.Generic;
using Esorb.Certificate.App.Database;
using System.Linq;

namespace Esorb.Certificate.App.Model
{
    public class CertificateModel
    {
        public DbHelper DbHelper { get; private set; } = new DbHelper();
        private CertificateSettings settings = new();
        public TrackableList<Teacher> Teachers { get; private set; } = new();
        public IList<Pupil> Pupils { get; private set; } = new List<Pupil>();
        public IList<SchoolClass> SchoolClasses { get; private set; } = new List<SchoolClass>();
        public IList<GradeLimit> GradeLimits { get; private set; } = new List<GradeLimit>();
        public IList<CertificateTemplate> CertificateTemplates { get; private set; } = new List<CertificateTemplate>();
        public IList<CertificateTemplatePage> CertificateTemplatePages { get; private set; } = new List<CertificateTemplatePage>();
        public IList<Subject> Subjects { get; private set; } = new List<Subject>();
        public CertificateData CertificateData { get; private set; } = new CertificateData();

        public CertificateModel()
        {
            if (DbHelper.IsCertificateFile(settings.DatabasePath))
            {
                BuildCertificateModel();
            }
        }

        public void BuildCertificateModel()
        {
            LoadCertificateModel();
            LinkCertificateModel();
        }
        public void LoadCertificateModel()
        {
            settings = new CertificateSettings();

            LoadTeachers();
            Pupils = DbHelper.LoadAll<Pupil>().OrderBy(pupil => pupil.FullName).ToList();
            SchoolClasses = DbHelper.LoadAll<SchoolClass>().OrderBy(schoolClass => schoolClass.ClassName).ToList();
            GradeLimits = DbHelper.LoadAll<GradeLimit>().OrderBy(gl => gl.GradeNumeric).ToList();
            CertificateTemplates = DbHelper.LoadAll<CertificateTemplate>().OrderBy(ct => ct.Yearlevel).ThenBy(ct => ct.HalfYear).ToList();
            CertificateTemplatePages = DbHelper.LoadAll<CertificateTemplatePage>().OrderBy(ctp => ctp.CertificateTemplateId).ThenBy(ctp => ctp.PageNumber).ToList();
            Subjects = DbHelper.LoadAll<Subject>();

            CertificateData = DbHelper.LoadAll<CertificateData>().ToList().FirstOrDefault() ?? new CertificateData();
        }

        public void LoadTeachers()
        {
            IEnumerable<Teacher> teachers = DbHelper.LoadAll<Teacher>().OrderBy(teacher => teacher.FullName);
            foreach (Teacher teacher in teachers)
            {
                Teachers.Add(teacher);
            }
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
            CertificateTemplatePages.Clear();
        }

        public void LinkCertificateModel()
        {
            LinkPupilsSchoolClasses();
            LinkCertificateTemplatePagesToCertificateTemplates();
            LinkSubjectsToCertificateTemplatePages();
        }
        public void LinkSubjectsToCertificateTemplatePages()
        {
            foreach (var subject in Subjects)
            {
                subject.CertificateTemplatePage =
                    CertificateTemplatePages.FirstOrDefault(ctp => ctp.ID == subject.CertificateTemplatePageId);
                subject.CertificateTemplatePage?.Subjects.Add(subject);
                subject.CertificateTemplate = subject.CertificateTemplatePage?.CertificateTemplate;
            }
        }
        private void LinkPupilsSchoolClasses()
        {
            foreach (var pupil in Pupils)
            {
                pupil.SchoolClass = SchoolClasses.FirstOrDefault(sc => sc.ID == pupil.SchoolClassId);
                pupil.SchoolClass?.Pupils.Add(pupil);
            }
        }
        private void LinkCertificateTemplatePagesToCertificateTemplates()
        {
            foreach (var ctp in CertificateTemplatePages)
            {
                ctp.CertificateTemplate = CertificateTemplates.FirstOrDefault(ct => ct.ID == ctp.CertificateTemplateId)!;
                ctp.CertificateTemplate?.CertificateTemplatePages.Add(ctp);
            }
        }


    }
}
