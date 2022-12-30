using Esorb.Certificate.PupilCsvFileService;

namespace Esorb.Certificate.UnitTests
{
    [TestClass]
    public class PupilSchoolClassImporterTests
    {
        [TestMethod]
        public void ReadRawDataOfTestfile_contains_8_Entries()
        {
            // Arrange
            var psci = new PupilSchoolClassImporter(@"C:\Users\frank\source\repos\Esorb\Certificate\Esorb.Certificate\Esorb.Certificate.UnitTests\TestData\PupilsClassesTest.csv");
            // Act
            psci.ReadRawData();
            int q = psci.RawDatas.Count;
            // Assert
            Assert.AreEqual(8, q);
        }

        [TestMethod]
        public void ReadRawDataOfTestFile_contains_correct_Values()
        {
            // Arrange
            var psci = new PupilSchoolClassImporter(@"C:\Users\frank\source\repos\Esorb\Certificate\Esorb.Certificate\Esorb.Certificate.UnitTests\TestData\PupilsClassesTest.csv");
            // Act
            psci.ReadRawData();
            // Assert
            Assert.AreEqual("Lieschen", psci.RawDatas[0].Firstname);
            Assert.AreEqual("Müller", psci.RawDatas[0].Lastname);
            Assert.AreEqual("4", psci.RawDatas[psci.RawDatas.Count - 1].YearLevel);
            Assert.AreEqual("08.05.2013", psci.RawDatas[4].DateOfBirth);
            Assert.AreEqual("03A", psci.RawDatas[1].ClassName);
        }
    }
}
