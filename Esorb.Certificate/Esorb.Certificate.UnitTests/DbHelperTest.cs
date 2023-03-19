using Esorb.Certificate.App.Database;

namespace Esorb.Certificate.UnitTests
{
    [TestClass]
    public class DbHelperTest
    {
        [TestMethod]
        public void IsSqliteFileForSqliteFIle_returns_true()
        {
            // Arrange
            var dbh = new DbHelper();
            // Act
            var result = dbh.IsSQLiteFile("C:/Users/frank/Documents/Versuche.db");
            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsSqliteFileForTextFile_returns_false()
        {
            // Arrange
            var dbh = new DbHelper();
            // Act
            var result = dbh.IsSQLiteFile("C:/Users/frank/Documents/cs.txt");
            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsSqliteFileForNotExistingFile_returns_false()
        {
            // Arrange
            var dbh = new DbHelper();
            // Act
            var result = dbh.IsSQLiteFile("C:/Users/frank/Documents/d03mfn.dcs");
            // Assert
            Assert.IsFalse(result);
        }
    }
}
