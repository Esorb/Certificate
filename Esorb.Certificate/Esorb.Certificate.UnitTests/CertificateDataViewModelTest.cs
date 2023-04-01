using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.Model;
using Esorb.Certificate.App.ViewModel;

namespace Esorb.Certificate.UnitTests
{
    [TestClass]
    public class CertificateDataViewModelTest
    {
        [TestMethod]
        public void CertificateDataViewModelChanges_are_immediatelly_saved_to_DB()
        {
            // Prepare
            var dbh = new DbHelper();
            dbh.DropTable(typeof(CertificateData).ToString());
            dbh.CreateTable(typeof(CertificateData).ToString());
            // Arrange
            var cd = new CertificateData();
            cd.SchoolYear = "2022 / 2023";
            cd.HalfYear = 2;
            cd.DateOfSchoolConference = new DateTime(2023, 04, 01);
            cd.DateOfCertificateDistribution = new DateTime(2023, 04, 15);
            cd.DateOfRestartLessons = new DateTime(2023, 07, 15);
            cd.TimeOfRestartLessons = DateTime.ParseExact("08:00:00 AM", "hh:mm:ss tt", CultureInfo.InvariantCulture);
            dbh.Save(cd);
            var cbvm = new CertificateDataViewModel(cd, dbh);
            // Act
            cbvm.SchoolYear = "2023 / 2024";
            CertificateData cd2 = dbh.LoadById<CertificateData>(cd.ID!);
            // Assert
            Assert.AreEqual("2023 / 2024", cd2.SchoolYear);

        }
    }
}
