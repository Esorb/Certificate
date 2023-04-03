using Esorb.Certificate.App.Database;
using System.Collections.Generic;

namespace Esorb.Certificate.App.Model
{
    public interface ICertificateModel
    {
        public DbHelper DbHelper { get; }
        CertificateData CertificateData { get; }
        IList<CertificateTemplate> CertificateTemplates { get; }
        IList<GradeLimit> GradeLimits { get; }
        IList<Pupil> Pupils { get; }
        IList<SchoolClass> SchoolClasses { get; }
        IList<Teacher> Teachers { get; }

        void ClearCertificateModel();
        void LinkCertificateModel();
        void LoadCertificateModel();
    }
}