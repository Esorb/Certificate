using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.Model;
using Esorb.Certificate.App.Model.Enumerables;

namespace Esorb.Certificate.UnitTests;

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
        t1.Gender = GenderValues.female;
        t1.IsHeadmaster = false;
        t1.IsAdmin = true;
        t1.Password = "password";

        var t2 = new Teacher();
        t2.FirstName = "Bettina";
        t2.LastName = "Nebel";
        t2.Gender = GenderValues.female;
        t2.IsHeadmaster = true;
        t2.IsAdmin = false;

        var t3 = new Teacher();
        t3.FirstName = "Caroline";
        t3.LastName = "Schäfer";
        t3.Gender = GenderValues.female;
        t3.IsHeadmaster = false;
        t3.IsAdmin = false;

        var t4 = new Teacher();
        t4.FirstName = "Herbert";
        t4.LastName = "Böttcher";
        t4.Gender = GenderValues.male;
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

    [TestMethod]
    public void LoadedTeacherById_Contains_Correct_Data()
    {
        // Arrange
        var dbh = new DbHelper();
        dbh.DropTable(typeof(Teacher).ToString());
        dbh.CreateTable(typeof(Teacher).ToString());

        var t1 = new Teacher();
        t1.FirstName = "Astrid";
        t1.LastName = "Heidelberg";
        t1.Gender = GenderValues.female;
        t1.IsHeadmaster = false;
        t1.IsAdmin = true;
        t1.Password = "password";

        var t2 = new Teacher();
        t2.FirstName = "Bettina";
        t2.LastName = "Nebel";
        t2.Gender = GenderValues.female;
        t2.IsHeadmaster = true;
        t2.IsAdmin = false;

        var t3 = new Teacher();
        t3.FirstName = "Caroline";
        t3.LastName = "Schäfer";
        t3.Gender = GenderValues.female;
        t3.IsHeadmaster = false;
        t3.IsAdmin = false;

        var t4 = new Teacher();
        t4.FirstName = "Herbert";
        t4.LastName = "Böttcher";
        t4.Gender = GenderValues.male;
        t4.IsHeadmaster = false;
        t4.IsAdmin = false;

        // Act

        dbh.Save(t1);
        dbh.Save(t2);
        dbh.Save(t3);
        dbh.Save(t4);
        if (string.IsNullOrEmpty(t3.ID))
        {
            Teacher Result = dbh.LoadById<Teacher>(t3.ID!);
            // Assert
            Assert.AreEqual(t3.FirstName, Result.FirstName);
        }

    }
    [TestMethod]
    public void UpdatedTeacher_Contains_Correct_Data()
    {
        // Arrange
        var dbh = new DbHelper();
        dbh.DropTable(typeof(Teacher).ToString());
        dbh.CreateTable(typeof(Teacher).ToString());

        var t1 = new Teacher();
        t1.FirstName = "Astrid";
        t1.LastName = "Heidelberg";
        t1.Gender = GenderValues.female;
        t1.IsHeadmaster = false;
        t1.IsAdmin = true;
        t1.Password = "password";

        var t2 = new Teacher();
        t2.FirstName = "Bettina";
        t2.LastName = "Nebel";
        t2.Gender = GenderValues.female;
        t2.IsHeadmaster = true;
        t2.IsAdmin = false;

        var t3 = new Teacher();
        t3.FirstName = "Caroline";
        t3.LastName = "Schäfer";
        t3.Gender = GenderValues.female;
        t3.IsHeadmaster = false;
        t3.IsAdmin = false;

        var t4 = new Teacher();
        t4.FirstName = "Herbert";
        t4.LastName = "Böttcher";
        t4.Gender = GenderValues.male;
        t4.IsHeadmaster = false;
        t4.IsAdmin = false;

        // Act

        dbh.Save(t4);
        dbh.Save(t3);
        dbh.Save(t2);
        dbh.Save(t1);
        t2.FirstName = "Henrietta";
        dbh.Save(t2);
        if (string.IsNullOrEmpty(t2.ID))
        {
            Teacher Result = dbh.LoadById<Teacher>(t2.ID!);
            // Assert
            Assert.AreEqual(t2.FirstName, Result.FirstName);
        }
        t2.FirstName = "Bettina";
        dbh.Save(t2);
    }

    [TestMethod]
    public void LoadAllTeachers_Returns_4_teachers()
    {
        // Arrange
        var dbh = new DbHelper();

        // Act
        IList<Teacher> teachers = dbh.LoadAll<Teacher>().OrderBy(teacher => teacher.FullName).ToList();

        // Assert
        Assert.AreEqual(4, teachers.Count);
    }

    [TestMethod]
    public void LoadAllTeachersSorted_Third_element_is_Caroline()
    {
        // Arrange
        var dbh = new DbHelper();

        // Act
        IList<Teacher> teachers = dbh.LoadAll<Teacher>().OrderBy(teacher => teacher.FullName).ToList();

        // Assert
        Assert.AreEqual("Caroline", teachers[2].FirstName);
    }

}
