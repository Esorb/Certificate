using Esorb.Certificate.App.PupilCsvFileService;

namespace Esorb.Certificate.UnitTests;

[TestClass]
public class PupilSchoolClassImporterTests
{
    [TestMethod]
    public void ReadRawDataOfTestfile_contains_8_Entries()
    {
        // Arrange
        var psci = new PupilSchoolClassImporter();
        // Act
        psci.ReadRawData(@"C:\Users\frank\source\repos\Esorb\Certificate\Esorb.Certificate\Esorb.Certificate.UnitTests\TestData\PupilsClassesTest.csv");
        int q = psci.RawDatas.Count;
        // Assert
        Assert.AreEqual(8, q);
    }

    [TestMethod]
    public void ReadRawDataOfTestFile_contains_correct_Values()
    {
        // Arrange
        var psci = new PupilSchoolClassImporter();
        // Act
        psci.ReadRawData(@"C:\Users\frank\source\repos\Esorb\Certificate\Esorb.Certificate\Esorb.Certificate.UnitTests\TestData\PupilsClassesTest.csv");
        // Assert
        Assert.AreEqual("Lieschen", psci.RawDatas[0].Firstname);
        Assert.AreEqual("Müller", psci.RawDatas[0].Lastname);
        Assert.AreEqual("4", psci.RawDatas[psci.RawDatas.Count - 1].YearLevel);
        Assert.AreEqual("08.05.2013", psci.RawDatas[4].DateOfBirth);
        Assert.AreEqual("03A", psci.RawDatas[1].ClassName);
    }

    [TestMethod]
    public void IsPupilSchoolClassFileOfNonExistentFile_returns_False()
    {
        // Arrange
        var psci = new PupilSchoolClassImporter();
        // Act
        var result = psci.IsPupilSchoolClassFile("C:/Users/frank/Documents/d03mfn.dcs");
        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsPupilSchoolClassFileForTextFile_returns_False()
    {
        // Arrange
        var psci = new PupilSchoolClassImporter();
        // Act
        var result = psci.IsPupilSchoolClassFile("C:/Users/frank/Documents/cs.txt");
        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsPupilSchoolClassFileForCsvFile_returns_False()
    {
        // Arrange
        var psci = new PupilSchoolClassImporter();
        // Act
        var result = psci.IsPupilSchoolClassFile("C:/Users/frank/Documents/cs.csv");
        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void IsPupilSchoolClassFileOfCorrectFiel_returns_True()
    {
        // Arrange
        var psci = new PupilSchoolClassImporter();
        // Act
        var result = psci.IsPupilSchoolClassFile("C:/Users/frank/source/repos/Esorb/Certificate/Esorb.Certificate/Esorb.Certificate.UnitTests/TestData/PupilsClassesTest.csv");
        // Assert
        Assert.IsTrue(result);
    }
}
