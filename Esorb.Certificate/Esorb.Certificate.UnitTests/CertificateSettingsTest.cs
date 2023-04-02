using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.UnitTests
{
    [TestClass]
    public class CertificateSettingsTest
    {
        [TestMethod]
        public void SettingsDataBasePath_is_Versuche()
        {
            // Arrange
            var csvm = new CertificateSettingsViewModel();
            // Assert
            Assert.AreEqual(@"C:\Users\frank\Documents\Versuche.db", csvm.DatabasePath);
        }

        [TestMethod]
        public void SettingChanges_are_saved()
        {
            // Arrange
            var csvm = new CertificateSettingsViewModel();
            // Act
            csvm.SchoolClass = "03A";
            csvm.Teacher = "Petra Brose";
            csvm.SchoolYear = "2022/2023";
            csvm.MenuPosition = "narrow";
            csvm.Page = "Info";
            var cs = new CertificateSettingsViewModel();
            // Assert
            Assert.AreEqual("03A", cs.SchoolClass);
            Assert.AreEqual("Petra Brose", cs.Teacher);
            Assert.AreEqual("2022/2023", cs.SchoolYear);
            Assert.AreEqual("narrow", cs.MenuPosition);
            Assert.AreEqual("Info", cs.Page);
        }
    }
}
