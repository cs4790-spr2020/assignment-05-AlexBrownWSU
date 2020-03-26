using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.ServicesTest
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void GetAllEmpty()
        {
            //Arrange
            InMemory plugin = new InMemory();
            UserAdapter adapter = new UserAdapter(plugin);
            ArrayList expected = new ArrayList();
            //Act
            IEnumerable actual = adapter.GetAll();
            //Assert
            Assert.AreEqual(expected.Count, (actual as ArrayList).Count);
        }
    }
}
