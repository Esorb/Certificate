using Esorb.Certificate.App.Database;
using System.Collections.Generic;

namespace Esorb.Certificate.App.Model
{
    public interface ICertificateModel
    {
        ICertificateData CertificateData { get; }
        IList<CertificateTemplate> CertificateTemplates { get; }
        IList<Pupil> Pupils { get; }
        IList<SchoolClass> SchoolClasses { get; }
        IList<Teacher> Teachers { get; }

        void LoadCertificateModel();
    }
}