using Esorb.Certificate.App.Database;

namespace Esorb.Certificate.UnitTests
{
    [TestClass]
    public class DbHelperTest
    {
        [TestMethod]
        public void IsCertificateFileForSqliteFIle_returns_true()
        {
            // Arrange
            var dbh = new DbHelper();
            // Act
            var result = dbh.IsCertificateFile("C:/Users/frank/Documents/Versuche.db");
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsCertificateFileForTextFile_returns_false()
        {
            // Arrange
            var dbh = new DbHelper();
            // Act
            var result = dbh.IsCertificateFile("C:/Users/frank/Documents/cs.txt");
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsCertificateFileForNotExistingFile_returns_false()
        {
            // Arrange
            var dbh = new DbHelper();
            // Act
            var result = dbh.IsCertificateFile("C:/Users/frank/Documents/d03mfn.dcs");
            // Assert
            Assert.IsFalse(result);
        }
    }
}
