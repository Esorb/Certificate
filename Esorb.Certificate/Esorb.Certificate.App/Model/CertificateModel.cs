using System.Collections.Generic;
using Esorb.Certificate.App.Database;
using System.Linq;

namespace Esorb.Certificate.App.Model
{
    public class CertificateModel
    {
        private static CertificateModel instance;
        public DbHelper DbHelper { get; private set; } = new DbHelper();
        private CertificateSettings settings = new();
        public IList<Teacher> Teachers { get; private set; } = new List<Teacher>();
        public IList<Pupil> Pupils { get; private set; } = new List<Pupil>();
        public IList<SchoolClass> SchoolClasses { get; private set; } = new List<SchoolClass>();
        public IList<GradeLimit> GradeLimits { get; private set; } = new List<GradeLimit>();
        public IList<CertificateTemplate> CertificateTemplates { get; private set; } = new List<CertificateTemplate>();
        public IList<CertificateTemplatePage> CertificateTemplatePages { get; private set; } = new List<CertificateTemplatePage>();
        public IList<Subject> Subjects { get; private set; } = new List<Subject>();

        public IList<Content> Contents { get; private set; } = new List<Content>();
        public CertificateData CertificateData { get; private set; } = new CertificateData();

        private CertificateModel()
        {
            if (DbHelper.IsCertificateFile(settings.DatabasePath))
            {
                BuildCertificateModel();
            }
        }

        public static CertificateModel GetInstance()
        {
            if (instance == null)
            {
                instance = new CertificateModel();
            }
            return instance;
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
            LoadPupils();
            LoadSchooClasses();
            LoadGradeLimits();
            LoadCertificateTemplates();
            LoadContents();
            LoadCertificateData();
            CertificateTemplatePages = DbHelper.LoadAll<CertificateTemplatePage>().OrderBy(ctp => ctp.CertificateTemplateId).ThenBy(ctp => ctp.PageNumber).ToList();
            Subjects = DbHelper.LoadAll<Subject>();

        }

        public void LoadTeachers()
        {
            IEnumerable<Teacher> teachers = DbHelper.LoadAll<Teacher>().OrderBy(teacher => teacher.FullName);
            foreach (Teacher teacher in teachers)
            {
                Teachers.Add(teacher);
            }
        }

        public void LoadPupils()
        {
            IEnumerable<Pupil> pupils = DbHelper.LoadAll<Pupil>().OrderBy(pupil => pupil.FullName);
            foreach (Pupil pupil in pupils)
            {
                Pupils.Add(pupil);
            }
        }

        public void LoadSchooClasses()
        {
            IEnumerable<SchoolClass> schoolClasses = DbHelper.LoadAll<SchoolClass>().OrderBy(schoolClass => schoolClass.ClassName);
            foreach (SchoolClass schoolClass in schoolClasses)
            {
                SchoolClasses.Add(schoolClass);
            }
        }

        public void LoadGradeLimits()
        {
            IEnumerable<GradeLimit> gradeLimits = DbHelper.LoadAll<GradeLimit>().OrderBy(gl => gl.GradeNumeric);
            foreach (GradeLimit gl in gradeLimits)
            {
                GradeLimits.Add(gl);
            }
        }

        public void LoadCertificateTemplates()
        {
            IEnumerable<CertificateTemplate> certificateTemplates = DbHelper.LoadAll<CertificateTemplate>().OrderBy(ct => ct.Yearlevel).ThenBy(ct => ct.HalfYear);
            foreach (CertificateTemplate certTemplate in certificateTemplates)
            {
                CertificateTemplates.Add(certTemplate);
            }
        }

        public void LoadContents()
        {
            IEnumerable<Content> contents = DbHelper.LoadAll<Content>().OrderBy(c => c.CertificateTemplateID).ThenBy(c => c.Position);
            foreach (Content content in contents)
            {
                Contents.Add(content);
            }
        }

        public void LoadCertificateData()
        {
            CertificateData = DbHelper.LoadAll<CertificateData>().ToList().FirstOrDefault() ?? new CertificateData();
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
            LinkContentsToCertificateTemplates();
            //LinkCertificateTemplatePagesToCertificateTemplates();
            //LinkSubjectsToCertificateTemplatePages();
            //LinkSubjectsToCertificateTemplates();
        }

        public void LinkContentsToCertificateTemplates()
        {
            foreach (Content content in Contents)
            {
                content.CertificateTemplate = CertificateTemplates.FirstOrDefault(ct => ct.ID == content.CertificateTemplateID);
                content.CertificateTemplate?.Contents.Add(content);
            }
        }

        //public static void LinkSubjectsToCertificateTemplates()
        //{

        //}
        //public void LinkSubjectsToCertificateTemplatePages()
        //{
        //    foreach (var subject in Subjects)
        //    {
        //        subject.CertificateTemplatePage =
        //            CertificateTemplatePages.FirstOrDefault(ctp => ctp.ID == subject.CertificateTemplatePageId);
        //        subject.CertificateTemplatePage?.Subjects.Add(subject);
        //        subject.CertificateTemplate = subject.CertificateTemplatePage?.CertificateTemplate;
        //    }
        //}
        private void LinkPupilsSchoolClasses()
        {
            foreach (Pupil pupil in Pupils)
            {
                pupil.SchoolClass = SchoolClasses.FirstOrDefault(sc => sc.ID == pupil.SchoolClassId);
                pupil.SchoolClass?.Pupils.Add(pupil);
            }
        }
        //private void LinkCertificateTemplatePagesToCertificateTemplates()
        //{
        //    foreach (var ctp in CertificateTemplatePages)
        //    {
        //        ctp.CertificateTemplate = (CertificateTemplate)CertificateTemplates.FirstOrDefault(ct => ct.ID == ctp.CertificateTemplateId)!;
        //        ctp.CertificateTemplate?.CertificateTemplatePages.Add(ctp);
        //    }
        //}


    }
}
