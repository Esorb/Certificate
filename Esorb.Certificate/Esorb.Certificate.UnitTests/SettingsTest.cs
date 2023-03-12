using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esorb.Certificate.App;

namespace Esorb.Certificate.UnitTests
{
    [TestClass]
    public class SettingsTest
    {
        [TestMethod]
        public void GetSettings_returns_Path()
        {
            //Arrange
            var cs = new CertificateSettings();

            //Act

            //Assert
            Assert.AreEqual("C:\\Users\\frank\\Documents\\Versuche.db", cs.DatabasePath);
        }

        [TestMethod]
        public void SettingsSave_returns_SavedValue()
        {
            //Arrange
            var cs = new CertificateSettings();

            //Act
            cs.Teacher = "Astrid Heidelberg";
            cs.Save();
            var cs2 = new CertificateSettings();

            //Assert
            Assert.AreEqual("Astrid Heidelberg", cs2.Teacher);

            //Act
            cs.Teacher = "";
            cs.Save();
            var cs3 = new CertificateSettings();

            //Assert
            Assert.AreEqual("", cs3.Teacher);
        }
    }
}
