using Esorb.Certificate.Model.ValueInputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.UnitTests
{
    [TestClass]
    public class RatingInputTests
    {
        [TestMethod]
        public void Assign_4_Returns_4stars()
        {
            // Arrange
            var ri = new RatingInput();
            // Act
            ri.ValueString = "4";
            // Assert
            Assert.AreEqual("****", ri.ValueString);
        }

        [TestMethod]
        public void Assign_4stars_Returns_4stars()
        {
            // Arrange
            var ri = new RatingInput();
            // Act
            ri.ValueString = "****";
            // Assert
            Assert.AreEqual("****", ri.ValueString);
        }

        [TestMethod]
        public void Assign_3_Returns_3stars()
        {
            // Arrange
            var ri = new RatingInput();
            // Act
            ri.ValueString = "3";
            // Assert
            Assert.AreEqual("***", ri.ValueString);
        }

        [TestMethod]
        public void Assign_3stars_Returns_3stars()
        {
            // Arrange
            var ri = new RatingInput();
            // Act
            ri.ValueString = "***";
            // Assert
            Assert.AreEqual("***", ri.ValueString);
        }

        [TestMethod]
        public void Assign_2_Returns_2stars()
        {
            // Arrange
            var ri = new RatingInput();
            // Act
            ri.ValueString = "2";
            // Assert
            Assert.AreEqual("**", ri.ValueString);
        }

        [TestMethod]
        public void Assign_2stars_Returns_2stars()
        {
            // Arrange
            var ri = new RatingInput();
            // Act
            ri.ValueString = "**";
            // Assert
            Assert.AreEqual("**", ri.ValueString);
        }

        [TestMethod]
        public void Assign_1_Returns_1stars()
        {
            // Arrange
            var ri = new RatingInput();
            // Act
            ri.ValueString = "1";
            // Assert
            Assert.AreEqual("*", ri.ValueString);
        }

        [TestMethod]
        public void Assign_1star_Returns_1star()
        {
            // Arrange
            var ri = new RatingInput();
            // Act
            ri.ValueString = "*";
            // Assert
            Assert.AreEqual("*", ri.ValueString);
        }

        [TestMethod]
        public void Assign_something_else_Returns_falsche_Eingabe()
        {
            // Arrange
            var ri = new RatingInput();
            // Act
            ri.ValueString = "*****";
            // Assert
            Assert.AreEqual("falsche Eingabe", ri.ValueString);
        }
    }
}
