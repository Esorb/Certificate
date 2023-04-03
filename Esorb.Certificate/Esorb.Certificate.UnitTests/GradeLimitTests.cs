using Esorb.Certificate.App.Database;
using Esorb.Certificate.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.UnitTests
{
    [TestClass]
    public class GradeLimitTests
    {
        [TestMethod]
        public void SaveGradeLimits_Return_6_Values()
        {
            // Arrage
            var dbh = new DbHelper();
            dbh.DropTable(typeof(GradeLimit).ToString());
            dbh.CreateTable(typeof(GradeLimit).ToString());
            var gl1 = new GradeLimit { PercentageLimit = 0.965, Grade = "sehr gut", GradeNumeric = 1 };
            var gl2 = new GradeLimit { PercentageLimit = 0.845, Grade = "gut", GradeNumeric = 2 };
            var gl3 = new GradeLimit { PercentageLimit = 0.695, Grade = "befriedigend", GradeNumeric = 3 };
            var gl4 = new GradeLimit { PercentageLimit = 0.495, Grade = "ausreichend", GradeNumeric = 4 };
            var gl5 = new GradeLimit { PercentageLimit = 0.195, Grade = "mangelhaft", GradeNumeric = 5 };
            var gl6 = new GradeLimit { PercentageLimit = 0.0, Grade = "ungenügend", GradeNumeric = 6 };
            // Act
            dbh.Save(gl1);
            dbh.Save(gl2);
            dbh.Save(gl3);
            dbh.Save(gl4);
            dbh.Save(gl5);
            dbh.Save(gl6);
            // Assert
            Assert.AreEqual(6, dbh.Count(typeof(GradeLimit).ToString()));
        }

        [TestMethod]
        public void GradeCalculator_Calculates_Correctly()
        {
            // Arrage
            IList<GradeLimit> gradeLimits = new List<GradeLimit>();
            var gl1 = new GradeLimit { PercentageLimit = 0.965, Grade = "sehr gut", GradeNumeric = 1 };
            gradeLimits.Add(gl1);
            var gl2 = new GradeLimit { PercentageLimit = 0.845, Grade = "gut", GradeNumeric = 2 };
            gradeLimits.Add(gl2);
            var gl3 = new GradeLimit { PercentageLimit = 0.695, Grade = "befriedigend", GradeNumeric = 3 };
            gradeLimits.Add(gl3);
            var gl4 = new GradeLimit { PercentageLimit = 0.495, Grade = "ausreichend", GradeNumeric = 4 };
            gradeLimits.Add(gl4);
            var gl5 = new GradeLimit { PercentageLimit = 0.195, Grade = "mangelhaft", GradeNumeric = 5 };
            gradeLimits.Add(gl5);
            var gl6 = new GradeLimit { PercentageLimit = 0.0, Grade = "ungenügend", GradeNumeric = 6 };
            gradeLimits.Add(gl6);

            GradeCalculator gc = new GradeCalculator(gradeLimits);

            // Assert
            Assert.AreEqual("sehr gut", gc.Calculate(8, 8));
            Assert.AreEqual("gut", gc.Calculate(24, 23));
            Assert.AreEqual("sehr gut", gc.Calculate(36, 35));
            Assert.AreEqual("ausreichend", gc.Calculate(44, 23));
            Assert.AreEqual("ungenügend", gc.Calculate(44, 2));
            Assert.AreEqual("ungenügend", gc.Calculate(44, 0));
            Assert.AreEqual("mangelhaft", gc.Calculate(44, 9));
            Assert.AreEqual("ausreichend", gc.Calculate(44, 30));
            Assert.AreEqual("befriedigend", gc.Calculate(44, 31));
            Assert.AreEqual("", gc.Calculate(0, 31));
        }

        [TestMethod]
        public void DataModelLoadsOnCreation_Contains_6_GradeLimits()
        {
            var cm = new CertificateModel();
            Assert.AreEqual(6, cm.GradeLimits.Count);
        }

    }
}
