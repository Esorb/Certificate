using Esorb.Certificate.App.Output;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.UnitTests;

[TestClass]
public class OutputTests
{
    [TestMethod]
    public void SaveAs_CreatesNewFile()
    {
        // CleanUp
        if (File.Exists(@"C:\Users\frank\source\repos\Esorb\Certificate\Esorb.Certificate\Esorb.Certificate.UnitTests\TestData\Zeugnis.docx"))
        {
            File.Delete(@"C:\Users\frank\source\repos\Esorb\Certificate\Esorb.Certificate\Esorb.Certificate.UnitTests\TestData\Zeugnis.docx");
        }
        // Arrange
        // Act
        WordVersuche.FirstTest();
        // Assert
        Assert.IsTrue(File.Exists(@"C:\Users\frank\source\repos\Esorb\Certificate\Esorb.Certificate\Esorb.Certificate.UnitTests\TestData\Zeugnis.docx"));
    }

    [TestMethod]
    public void SaveAs_CreatesNewFile1()
    {
        // CleanUp
        if (File.Exists(@"C:\Users\frank\source\repos\Esorb\Certificate\Esorb.Certificate\Esorb.Certificate.UnitTests\TestData\Zeugnis1.docx"))
        {
            File.Delete(@"C:\Users\frank\source\repos\Esorb\Certificate\Esorb.Certificate\Esorb.Certificate.UnitTests\TestData\Zeugnis1.docx");
        }
        // Arrange
        // Act
        WordVersuche.SecondTest();
        // Assert
        Assert.IsTrue(File.Exists(@"C:\Users\frank\source\repos\Esorb\Certificate\Esorb.Certificate\Esorb.Certificate.UnitTests\TestData\Zeugnis1.docx"));
    }
}
