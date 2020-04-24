using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlabberApp.DataStore.Adapters;
using BlabberApp.DataStore.Plugins;
using BlabberApp.Domain.Entities;
using System;

namespace BlabberApp.DataStoreTest
{
    [TestClass]
    public class BlabAdapter_MySql_UnitTests
    {
        private BlabAdapter _harness;
        private Blab _testBlab;
        private string _testEmail;
        private User _testUser;
        private BlabAdapter adapter = new BlabAdapter(new MySqlBlab());
        private string _message = "test";


        [TestInitialize]
        public void Setup()
        {
            _harness = new BlabAdapter(new MySqlBlab());
            _testEmail = "example@example.com";
            _testUser = new User(_testEmail);    
            _testBlab = new Blab("test", _testUser);
            _harness.RemoveAll();
        }
        [TestCleanup]
        public void TearDown()
        {
            _harness.RemoveAll();
        }

        [TestMethod]
        public void Canary()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod]
        public void TestAddAndGetBlab()
        {
            //Arrange
            string email = "fooabar@example.com";
            User mockUser = new User(email);
            Blab blab = new Blab("test", mockUser);
            //Act
            _harness.Add(blab);
            ArrayList actual = (ArrayList)_harness.GetByUserId(email);
            //Assert
            Assert.AreEqual(1, actual.Count);
        }
        [TestMethod]
        public void TestAddAndGetAll()
        {
            //Arrange
            Blab blab = new Blab(_message, _testUser);
            User mockUser = new User("example123@test.net");
            Blab blabTwo = new Blab(_message, mockUser);
            //Act
            _harness.Add(blab);
            _harness.Add(blabTwo);
            ArrayList actual = (ArrayList)_harness.GetAll();
            //Assert
            Assert.AreEqual(2, actual.Count);
        }
        [TestMethod]
        public void TestAddAndGetByBlabID()
        { 
            //Act
            _harness.Add(_testBlab);

            //Retrieve from DB by email
            Blab actual = _harness.GetByBlabId(_testBlab.Id);

            //Assert
            Assert.AreEqual(_testBlab.Id.ToString(), actual.Id.ToString());
            Assert.AreEqual(_testBlab.Id.ToString(), actual.Id.ToString());
        }
        [TestMethod]
        public void TestAddAndGetAllByUserEmail()
        { 
            //Act
            _harness.Add(_testBlab);

            //Retrieve from DB by email
            ArrayList actual = (ArrayList)_harness.GetByUserId (_testEmail);

            //Assert
            Assert.AreEqual(1, actual.Count);
        }
        [TestMethod]
        public void TestAddAndUpdateBlab()
        {
            //Add to DB
            _harness.Add(_testBlab);

            //Update blab by Guid Id
            _harness.UpdateBlabById(_testBlab.Id, "test");

            //Retrieve blab from db by Guid Id
            Blab _updatedBlab = _harness.GetByBlabId(_testBlab.Id);

            //Assert
            Assert.AreNotEqual(_testBlab.Message, _updatedBlab.Message);
            //Assert.AreEqual("This is a new message", _updatedBlab.Message);
        }
        [TestMethod]
        public void UpdateBlab(){

        }

        [TestMethod]
        public void getById(){

        }
         [TestMethod]
         public void TestAddAndDelete()
        { 
            //Act
            _harness.Add(_testBlab);

            //Delete From DB
            _harness.Remove(_testBlab);

            //Retrieve from DB by email, returns null if no row found
            Blab actual = _harness.GetByBlabId(_testBlab.Id);

            //Assert
            Assert.AreNotEqual(_testBlab, actual);
        }
        [TestMethod]
        public void TestRemoveAll()
        {
            //Arrange
            BlabAdapter actual = _harness;
            Blab blab = new Blab(_message, _testUser);
            User mockUser = new User("testme@test.net");
            Blab blabTwo = new Blab(_message, mockUser);
            //Act
            _harness.Add(blab);
            _harness.Add(blabTwo);
            _harness.RemoveAll();
            //Assert
            Assert.AreEqual(_harness.ToString(), actual.ToString());
        }
        
     [TestMethod]
        public void TestBlabUpdate()
        {
            //Arrange
            Blab blab = new Blab(_message, _testUser);
            //Act
            _harness.Add(blab);
            blab.Message = "test";
            _harness.Update(blab);
            ArrayList actual = (ArrayList)_harness.GetByUserId(_testUser.Email);
            Blab mockBlab = (Blab)actual[0];
            //Assert
            Assert.AreEqual(blab.Message.ToString(), mockBlab.Message.ToString());
        }
    }
}
