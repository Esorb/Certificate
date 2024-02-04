using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.Model;

namespace Esorb.Certificate.UnitTests
{
    [TestClass]
    public class CertificateTemplate2PageTest
    {
        [TestMethod]
        public void CreateCertificateTemplatePages_results_in_24_Pages()
        {
            // Arrange
            var dbh = new DbHelper();
            dbh.DropTable(typeof(CertificateTemplatePage).ToString());
            dbh.CreateTable(typeof(CertificateTemplatePage).ToString());

            List<CertificateTemplate> cts = new();
            cts = dbh.LoadAll<CertificateTemplate>().OrderBy(ct => ct.Yearlevel).ThenBy(ct => ct.HalfYear).ToList();
            CertificateTemplatePage ctp;

            // Act
            foreach (CertificateTemplate ct in cts)
            {
                for (int i = 1; i <= 4; i++)
                {
                    ctp = new CertificateTemplatePage
                    {
                        CertificateTemplateId = ct.ID!,
                        PageNumber = i
                    };
                    ct.CertificateTemplatePages.Add(ctp);
                    dbh.Save(ctp);
                }
            }

            // Assert
            Assert.AreEqual(cts.Count * 4, dbh.Count(typeof(CertificateTemplatePage).ToString()));
        }
    }
}
