using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WhosThat;
using WhosThat.Recognition;

namespace unittests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIdFactory()
        {
            int initial_value = 4;
            int expected = 5;

            WhosThat.IdFactory.SetCurrentId(initial_value);

            int actual = WhosThat.IdFactory.GetCurrentId();
            Assert.AreEqual(actual, expected);

        }
        [TestMethod]
        public void findPersonByIDTest()
        {
            Person personTest = new Person("name", "nice", "nice");
            int beginningID = 0; Person personExpected = personTest;
            Storage.People.Add(personTest);
            Person personActual = Storage.findPersonByID(beginningID);
            Assert.AreEqual(personExpected, personActual);

        }
    }
}
