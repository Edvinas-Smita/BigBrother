using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

            WhosThat.IdFactory.NextId = initial_value;

            int actual = WhosThat.IdFactory.NextId;
            Assert.AreEqual(actual, expected);

        }
    }
}
