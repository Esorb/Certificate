using Esorb.Certificate.Model;
using Esorb.School_Certificate.Model;
using Microsoft.EntityFrameworkCore;
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
            var p = new Pupil();

            // Act
            p.FirstName = "Max";
            p.LastName = "Mustermann";

            // Assert
            Assert.AreEqual("Max Mustermann", p.FullName);
        }

        [TestMethod]
        public void PupilsTableAfterAddingTwoPupils_contains_2_Pupils()
        {
            // Arrange

            var sc = new SchoolClass()
            {
                ClassName = "1A",
                Yearlevel = 1,
                HalfYear = 2
            };

            using (var data = new CertificateContext())
            {
                data.Pupils.ExecuteDelete();
                data.SchoolClasses.ExecuteDelete();
                data.Add(sc);
                data.SaveChanges();

                var p1 = new Pupil()
                {
                    FirstName = "Hans",
                    LastName = "Müller",
                    DateOfBirth = new DateOnly(2014, 8, 13),
                    YearsAtSchool = 1,
                    SchoolClassId = sc.SchoolClassId
                };

                var p2 = new Pupil()
                {
                    FirstName = "Maria",
                    LastName = "Maier",
                    DateOfBirth = new DateOnly(2013, 2, 25),
                    YearsAtSchool = 2,
                    SchoolClassId = sc.SchoolClassId
                };

                // Act
                data.Add(p1);
                data.Add(p2);
                data.SaveChanges();

                // Assert
                Assert.AreEqual(2, data.Pupils.Count());
            }
        }
    }
}