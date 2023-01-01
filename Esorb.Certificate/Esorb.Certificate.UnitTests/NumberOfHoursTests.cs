using Esorb.Certificate.Model.ValueInputs;
using Esorb.Certificate.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esorb.Certificate.UnitTests
{
    [TestClass]
    public class NumberOfHoursTests
    {
        [TestMethod]
        public void ValidValueAssignement_ReturnsValue()
        {
            // Arrange
            var noh = new NumberOfHoursInput
            {
                // Act
                ValueString = "5"
            };
            // Assert
            Assert.AreEqual("5", noh.ValueString);
        }

        [TestMethod]
        public void NegativeValueAssignement_ReturnsZero()
        {
            // Arrange
            var noh = new NumberOfHoursInput
            {
                // Act
                ValueString = "-5"
            };
            // Assert
            Assert.AreEqual("0", noh.ValueString);
        }

        [TestMethod]
        public void InvalidValueAssignement_ReturnsZero()
        {
            // Arrange
            var noh = new NumberOfHoursInput
            {
                // Act
                ValueString = "Hello World"
            };
            // Assert
            Assert.AreEqual("0", noh.ValueString);
        }

    }
}
