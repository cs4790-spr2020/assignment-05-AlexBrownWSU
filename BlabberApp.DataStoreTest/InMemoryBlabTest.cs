using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class InMemory_Blab_UnitTests 
    {
        private InMemory<Blab> _harness;
        public InMemory_Blab_UnitTests()
        {
            _harness = new InMemory<Blab>();
        }

        [TestMethod]
        public void Add_Blab_GetByUserId_Success()
        {
            // Arrange
            string Email = "foo@example.com";
            Blab Expected = new Blab();
            Expected.Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer gravida posuere pretium. Cras maximus nibh sed accumsan elementum. Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            Expected.UserID = Email;
            _harness.Add(Expected);
            // Act
            Blab Actual = (Blab)_harness.GetByUserId(Email);
            // Assert
            Assert.AreEqual(Expected, Actual);
        }
    }
}
