using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class UserAdapter_MySql_UnitTests
    {
        private UserAdapter _harness = new UserAdapter(new MySqlUser());

        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestAddAndGetUser()
        {
            //Arrange
            User user = new User("foobar@example.com");
            user.RegisterDTTM =DateTime.Now;
            user.LastLoginDTTM = DateTime.Now;
            Console.WriteLine(user.Id.ToString());
            //Act
            _harness.Add(user);
            User actual = _harness.GetById(user.Id);
            //Assert
            Assert.AreEqual(user.Id, actual.Id);
        }
    }
}
