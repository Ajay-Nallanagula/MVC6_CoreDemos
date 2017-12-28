using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MVC6DemosUnitTest
{
    [TestClass]
    public class CalculatorTests
    {
        private int a,b;

        [TestInitialize]
        public void TestInitialize()
        {
            a = 100;
            b = 90;
        }

        [TestCategory("Build"), TestMethod]
        public void AddTest()
        {
            Assert.IsTrue(a+b ==190);
        }

        [TestCategory("Build"), TestMethod]
        public void SubtractTest()
        {
            Assert.IsTrue(a - b == 10);
        }

        [TestCategory("Build"), TestMethod]
        public void ProductTest()
        {
            Assert.IsTrue(a * b == 9000);
        }

        [TestCategory("Build"), TestMethod]
        public void RemainderTest()
        {
            Assert.IsTrue(a%b == 10);
        }
    }
}
