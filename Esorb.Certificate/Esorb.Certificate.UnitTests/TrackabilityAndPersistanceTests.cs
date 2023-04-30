using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.Model.Enumerables;
using Esorb.Certificate.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.UnitTests
{
    [TestClass]
    public class TrackabilityAndPersistanceTests
    {
        [TestMethod]
        public void TracebleItem_Contains_Containing_Lists()
        {
            DbHelper dbh = new();
            dbh.DropTable(typeof(Teacher).ToString());
            dbh.CreateTable(typeof(Teacher).ToString());

            TrackableList tl1 = new();
            TrackableList tl2 = new();

            var t1 = new Teacher
            {
                FirstName = "Astrid",
                LastName = "Heidelberg",
                Gender = GenderValues.weiblich,
                IsHeadmaster = false,
                IsAdmin = true,
                Password = "password"
            };
            t1.Save();

            var t2 = new Teacher
            {
                FirstName = "Bettina",
                LastName = "Nebel",
                Gender = GenderValues.weiblich,
                IsHeadmaster = true,
                IsAdmin = false
            };
            t2.Save();

            var t3 = new Teacher
            {
                FirstName = "Caroline",
                LastName = "Schäfer",
                Gender = GenderValues.weiblich,
                IsHeadmaster = false,
                IsAdmin = false
            };
            t3.Save();

            var t4 = new Teacher
            {
                FirstName = "Herbert",
                LastName = "Böttcher",
                Gender = GenderValues.männlich,
                IsHeadmaster = false,
                IsAdmin = false
            };
            t4.Save();

            // Act

            tl1.Add(t1);
            tl1.Add(t2);
            tl1.Add(t3);
            tl1.Add(t4);
            tl2.Add(t1);
            tl2.Add(t2);
            tl2.Add(t3);
            tl2.Add(t4);

            var sharedDbHelper = t1.DbHelper;


            // Assert

            Assert.AreEqual(4, tl1.Count);
            Assert.AreEqual(4, tl2.Count);
            Assert.IsTrue(object.ReferenceEquals(sharedDbHelper, t2.DbHelper));
            Assert.IsTrue(object.ReferenceEquals(sharedDbHelper, t3.DbHelper));
            Assert.IsTrue(object.ReferenceEquals(sharedDbHelper, t4.DbHelper));

            // Act
            t1.Delete();
            // Assert
            Assert.AreEqual(3, tl1.Count);
            Assert.AreEqual(3, tl2.Count);

            // Act
            t2.Delete();

            // Assert
            Assert.AreEqual(2, tl1.Count);
            Assert.AreEqual(2, tl2.Count);

            // Act
            IList<Teacher> teachers = dbh.LoadAll<Teacher>().OrderBy(teacher => teacher.FullName).ToList();

            // Assert
            Assert.AreEqual(2, teachers.Count);
        }
    }
}
