using Esorb.Certificate.Model;
using Esorb.Certificate.Database;
using System.Linq;

namespace Esorb.Certificate.UnitTests
{
    [TestClass]
    public class PupilTests
    {
        [TestMethod]
        public void PupilsFullNameAfterInitialisation_Is_Blank()
        {
            // Arrange
            var p = new Pupil();

            // Act

            // Assert
            Assert.AreEqual(" ", p.FullName);
        }

        [TestMethod]
        public void PupilsFullNameAfterNameSetting_Is_Max_Mustermann()
        {
            // Arrange
            var p = new Pupil
            {
                // Act
                FirstName = "Max",
                LastName = "Mustermann"
            };

            // Assert
            Assert.AreEqual("Max Mustermann", p.FullName);
        }

        [TestMethod]
        public void PupilsTableAfterAddingTwoPupils_contains_2_Pupils()
        {
            // Prepare
            var dbh = new DbHelper();
            //dbh.DropTable(typeof(Pupil).ToString());
            //dbh.CreateTable(typeof(Pupil).ToString());
            //dbh.DropTable(typeof(SchoolClass).ToString());
            //dbh.CreateTable(typeof(SchoolClass).ToString());

            // Arrange
            var sc = new SchoolClass()
            {
                ClassName = "1A",
                Yearlevel = 1,
                HalfYear = 2
            };

            dbh.Save(sc);

            var p1 = new Pupil()
            {
                FirstName = "Hans",
                LastName = "Müller",
                DateOfBirth = new DateTime(2014, 8, 13),
                YearsAtSchool = 1,
                SchoolClassId = sc.ID
            };

            var p2 = new Pupil()
            {
                FirstName = "Maria",
                LastName = "Maier",
                DateOfBirth = new DateTime(2013, 2, 25),
                YearsAtSchool = 2,
                SchoolClassId = sc.ID
            };

            // Act
            dbh.Save(p1);
            dbh.Save(p2);

            // Assert
            Assert.AreEqual(2, dbh.Count(typeof(Pupil).ToString()));
        }
    }
}