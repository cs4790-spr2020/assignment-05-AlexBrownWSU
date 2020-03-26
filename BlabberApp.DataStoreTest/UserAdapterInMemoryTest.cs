using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Entities;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class UserAdapter_InMemory_UnitTests 
    {
        private UserAdapter _harness = new UserAdapter(new InMemory());

        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }
    }
}
