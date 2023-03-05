using Esorb.Certificate.Database;
using Esorb.Certificate.Model;

namespace Esorb.Certificate.UnitTests
{
    [TestClass]
    public class TeacherTests
    {
        [TestMethod]
        public void TeachersTableAfterAddingFourTeacgers_contains_4_Teachers()
        {
            // Arrange
            var dbh = new DbHelper();
            dbh.DropTable(typeof(Teacher).ToString());
            dbh.CreateTable(typeof(Teacher).ToString());

            var t1 = new Teacher();
            t1.FirstName = "Astrid";
            t1.LastName = "Heidelberg";
            t1.Gender = Model.Enumerables.GenderValues.female;
            t1.IsHeadmaster = false;
            t1.IsAdmin = true;
            t1.Password = "password";

            var t2 = new Teacher();
            t2.FirstName = "Bettina";
            t2.LastName = "Nebel";
            t2.Gender = Model.Enumerables.GenderValues.female;
            t2.IsHeadmaster = true;
            t2.IsAdmin = false;

            var t3 = new Teacher();
            t3.FirstName = "Caroline";
            t3.LastName = "Schäfer";
            t3.Gender = Model.Enumerables.GenderValues.female;
            t3.IsHeadmaster = false;
            t3.IsAdmin = false;

            var t4 = new Teacher();
            t4.FirstName = "Herbert";
            t4.LastName = "Böttcher";
            t4.Gender = Model.Enumerables.GenderValues.male;
            t4.IsHeadmaster = false;
            t4.IsAdmin = false;

            // Act

            dbh.Save(t1);
            dbh.Save(t2);
            dbh.Save(t3);
            dbh.Save(t4);

            // Assert
            Assert.AreEqual(4, dbh.Count(typeof(Teacher).ToString()));
        }

        //[TestMethod]
        public void LoadedTeacherById_Contains_Correct_Data()
        {
            // Arrange
            var dbh = new DbHelper();
            dbh.DropTable(typeof(Teacher).ToString());
            dbh.CreateTable(typeof(Teacher).ToString());

            var t1 = new Teacher();
            t1.FirstName = "Astrid";
            t1.LastName = "Heidelberg";
            t1.Gender = Model.Enumerables.GenderValues.female;
            t1.IsHeadmaster = false;
            t1.IsAdmin = true;
            t1.Password = "password";

            var t2 = new Teacher();
            t2.FirstName = "Bettina";
            t2.LastName = "Nebel";
            t2.Gender = Model.Enumerables.GenderValues.female;
            t2.IsHeadmaster = true;
            t2.IsAdmin = false;

            var t3 = new Teacher();
            t3.FirstName = "Caroline";
            t3.LastName = "Schäfer";
            t3.Gender = Model.Enumerables.GenderValues.female;
            t3.IsHeadmaster = false;
            t3.IsAdmin = false;

            var t4 = new Teacher();
            t4.FirstName = "Herbert";
            t4.LastName = "Böttcher";
            t4.Gender = Model.Enumerables.GenderValues.male;
            t4.IsHeadmaster = false;
            t4.IsAdmin = false;

            // Act

            dbh.Save(t1);
            dbh.Save(t2);
            dbh.Save(t3);
            dbh.Save(t4);
            if (string.IsNullOrEmpty(t3.ID))
            {
                Teacher Result = (Teacher)dbh.LoadById<Teacher>(t3.ID);
                // Assert
                Assert.AreEqual(t3.FirstName, Result.FirstName);
            }

        }
    }
}
