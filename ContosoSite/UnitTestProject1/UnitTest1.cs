using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Initialization() => Console.WriteLine("Init code goes here");

        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("Testing code goes here");
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            Console.WriteLine("Cleanup code goes here");
        }
    }
}
