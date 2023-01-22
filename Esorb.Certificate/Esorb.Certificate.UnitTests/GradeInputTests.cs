using Esorb.Certificate.Model.ValueInputs;
using Esorb.Certificate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.UnitTests
{
    [TestClass]
    public class GradeInputTests
    {
        [TestMethod]
        public void Assign_1_Returns_sehr_gut()
        {
            // Arrange
            var gi = new GradeInput();
            // Act
            gi.ValueString = "1";
            // Assert
            Assert.AreEqual("sehr gut", gi.ValueString);
        }

        [TestMethod]
        public void Assign_sehr_gut_Returns_sehr_gut()
        {
            // Arrange
            var gi = new GradeInput();
            // Act
            gi.ValueString = "sehr gut";
            // Assert
            Assert.AreEqual("sehr gut", gi.ValueString);
        }

        [TestMethod]
        public void Assign_2_Returns_gut()
        {
            // Arrange
            var gi = new GradeInput();
            // Act
            gi.ValueString = "2";
            // Assert
            Assert.AreEqual("gut", gi.ValueString);
        }

        [TestMethod]
        public void Assign_gut_Returns_gut()
        {
            // Arrange
            var gi = new GradeInput();
            // Act
            gi.ValueString = "gut";
            // Assert
            Assert.AreEqual("gut", gi.ValueString);
        }

        [TestMethod]
        public void Assign_3_Returns_befriedigend()
        {
            // Arrange
            var gi = new GradeInput();
            // Act
            gi.ValueString = "3";
            // Assert
            Assert.AreEqual("befriedigend", gi.ValueString);
        }

        [TestMethod]
        public void Assign_befriedigend_Returns_befriedigend()
        {
            // Arrange
            var gi = new GradeInput();
            // Act
            gi.ValueString = "befriedigend";
            // Assert
            Assert.AreEqual("befriedigend", gi.ValueString);
        }

        [TestMethod]
        public void Assign_4_Returns_ausreichend()
        {
            // Arrange
            var gi = new GradeInput();
            // Act
            gi.ValueString = "4";
            // Assert
            Assert.AreEqual("ausreichend", gi.ValueString);
        }

        [TestMethod]
        public void Assign_ausreichend_Returns_ausreichend()
        {
            // Arrange
            var gi = new GradeInput();
            // Act
            gi.ValueString = "ausreichend";
            // Assert
            Assert.AreEqual("ausreichend", gi.ValueString);
        }

        [TestMethod]
        public void Assign_5_Returns_mangelhaft()
        {
            // Arrange
            var gi = new GradeInput();
            // Act
            gi.ValueString = "5";
            // Assert
            Assert.AreEqual("mangelhaft", gi.ValueString);
        }

        [TestMethod]
        public void Assign_mangelhaft_Returns_mangelhaft()
        {
            // Arrange
            var gi = new GradeInput();
            // Act
            gi.ValueString = "mangelhaft";
            // Assert
            Assert.AreEqual("mangelhaft", gi.ValueString);
        }

        [TestMethod]
        public void Assign_6_Returns_ungenuegend()
        {
            // Arrange
            var gi = new GradeInput();
            // Act
            gi.ValueString = "6";
            // Assert
            Assert.AreEqual("ungenügend", gi.ValueString);
        }

        [TestMethod]
        public void Assign_ungenuegend_Returns_ungenuegend()
        {
            // Arrange
            var gi = new GradeInput();
            // Act
            gi.ValueString = "ungenügend";
            // Assert
            Assert.AreEqual("ungenügend", gi.ValueString);
        }

        [TestMethod]
        public void Assign_something_else_Returns_falsche_Eingabe()
        {
            // Arrange
            var gi = new GradeInput();
            // Act
            gi.ValueString = "7";
            // Assert
            Assert.AreEqual("falsche Eingabe", gi.ValueString);
        }
    }
}
