using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esorb.Certificate.App.Model;
using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.ViewModel;

namespace Esorb.Certificate.UnitTests
{
    [TestClass]
    public class CertificateTemplateTest
    {
        [TestMethod]
        public void CreateTemplates_result_in_6_Templates()
        {
            // Prepare
            var dbh = new DbHelper();
            dbh.DropTable(typeof(CertificateTemplate).ToString());
            dbh.CreateTable(typeof(CertificateTemplate).ToString());

            Assert.AreEqual(0, dbh.Count(typeof(CertificateTemplate).ToString()));

            // Arrange
            CertificateTemplate ct1 = new();
            CertificateTemplate ct2 = new();
            CertificateTemplate ct3 = new();
            CertificateTemplate ct4 = new();
            CertificateTemplate ct5 = new();
            CertificateTemplate ct6 = new();
            CertificateTemplateViewModel ct1VM = new(ct1, dbh);
            CertificateTemplateViewModel ct2VM = new(ct2, dbh);
            CertificateTemplateViewModel ct3VM = new(ct3, dbh);
            CertificateTemplateViewModel ct4VM = new(ct4, dbh);
            CertificateTemplateViewModel ct5VM = new(ct5, dbh);
            CertificateTemplateViewModel ct6VM = new(ct6, dbh);

            Assert.AreEqual(0, dbh.Count(typeof(CertificateTemplate).ToString()));

            // Act
            ct1VM.Yearlevel = 1;
            ct1VM.IsFullYearReport = true;

            Assert.AreEqual(1, dbh.Count(typeof(CertificateTemplate).ToString()));

            ct2VM.Yearlevel = 2;
            ct2VM.IsFullYearReport = true;

            Assert.AreEqual(2, dbh.Count(typeof(CertificateTemplate).ToString()));

            ct3VM.Yearlevel = 3;
            ct3VM.HalfYear = 1;
            ct3VM.IsFullYearReport = false;

            Assert.AreEqual(3, dbh.Count(typeof(CertificateTemplate).ToString()));

            ct4VM.Yearlevel = 3;
            ct4VM.HalfYear = 2;
            ct4VM.IsFullYearReport = false;

            Assert.AreEqual(4, dbh.Count(typeof(CertificateTemplate).ToString()));

            ct5VM.Yearlevel = 4;
            ct5VM.HalfYear = 1;
            ct5VM.IsFullYearReport = false;

            Assert.AreEqual(5, dbh.Count(typeof(CertificateTemplate).ToString()));

            ct6VM.Yearlevel = 4;
            ct6VM.HalfYear = 2;
            ct6VM.IsFullYearReport = false;

            Assert.AreEqual(6, dbh.Count(typeof(CertificateTemplate).ToString()));

            CertificateTemplate ct7 = dbh.LoadById<CertificateTemplate>(ct1.ID);

            Assert.AreEqual(2, ct1.HalfYear);
            Assert.AreEqual(2, ct7.HalfYear);
        }
    }
}
