using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DomainTest.Entities
{
    [TestClass]
    public class BlabTest
    {       
        private Blab harness;
        public BlabTest() 
        {
            harness = new Blab();
        }
        [TestMethod]
        public void TestSetGetMessage()
        {
            // Arrange
            string expected = "test"; 
            harness.Message = "test";
            // Act
            string actual = harness.Message;
            // Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestUpdateMessage()
        {
            // Arrange
            Blab actual = new Blab("test");
            // Act
            actual.Message = harness.Message;
            // Assert
            Assert.AreEqual(actual.Message, harness.Message);
        }

        [TestMethod]
        public void TestId()
        {
            // Arrange
            Guid expected = harness.Id;
            // Act
            Guid actual = harness.Id;
            // Assert
            Assert.AreEqual(actual, expected);
            Assert.AreEqual(true, harness.Id is Guid);
        }
        
        [TestMethod]
        public void TestDTTM()
        {
            // Arrange
            Blab Expected = new Blab();
            // Act
            Blab Actual = new Blab();
            // Assert
            Assert.AreEqual(Expected.DTTM.ToString(), Actual.DTTM.ToString());
        }
    }
}
