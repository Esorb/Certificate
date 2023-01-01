using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esorb.Certificate.Model.ValueInputs;

namespace Esorb.Certificate.UnitTests
{
    [TestClass]
    public class YesNoDecisionTests
    {
        [TestMethod]
        public void Assign_Ja_ReturnsJa()
        {
            // Arrange
            var ynd = new YesNoDecisionInput
            {
                // Act
                ValueString = "Ja"
            };
            // Assert
            Assert.AreEqual("Ja", ynd.ValueString);
        }

        [TestMethod]
        public void Assign_ja_ReturnsJa()
        {
            // Arrange
            var ynd = new YesNoDecisionInput
            {
                // Act
                ValueString = "ja"
            };
            // Assert
            Assert.AreEqual("Ja", ynd.ValueString);
        }
        [TestMethod]
        public void Assign_JA_ReturnsJa()
        {
            // Arrange
            var ynd = new YesNoDecisionInput
            {
                // Act
                ValueString = "JA"
            };
            // Assert
            Assert.AreEqual("Ja", ynd.ValueString);
        }

        [TestMethod]
        public void Assign_J_ReturnsJa()
        {
            // Arrange
            var ynd = new YesNoDecisionInput
            {
                // Act
                ValueString = "J"
            };
            // Assert
            Assert.AreEqual("Ja", ynd.ValueString);
        }

        [TestMethod]
        public void Assign_j_ReturnsJa()
        {
            // Arrange
            var ynd = new YesNoDecisionInput
            {
                // Act
                ValueString = "j"
            };
            // Assert
            Assert.AreEqual("Ja", ynd.ValueString);
        }

        [TestMethod]
        public void Assign_Nein_ReturnsNein()
        {
            // Arrange
            var ynd = new YesNoDecisionInput
            {
                // Act
                ValueString = "Nein"
            };
            // Assert
            Assert.AreEqual("Nein", ynd.ValueString);
        }

        [TestMethod]
        public void Assign_Something_ReturnsNein()
        {
            // Arrange
            var ynd = new YesNoDecisionInput
            {
                // Act
                ValueString = "3(#djs"
            };
            // Assert
            Assert.AreEqual("Nein", ynd.ValueString);
        }
    }
}
