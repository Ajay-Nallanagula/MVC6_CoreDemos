using System.Collections.Generic;
using System.Linq;
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

        [TestCategory("Build"), TestMethod]
        public void TestStringContains()
        {
            //"COMPANYPROFILEID","PORZIOGSTPROFILEID",
            var str =
                "TESTCP,PRP,PST,PROFILELOV,NEWCUSTOMLOV,PROFILELOVTEST,PROFILEDATE,PROFILECOUNT,PROFILETRCOUNT,AMOUS,STANDARD,BAX,DECIVAL,BUG,DECIMALCP,JERRYTOM,SOME,DRIMP,REDDY,TESTCUSTOMAJAY,REDDY,DUDE,PROFILECOUNT,ASDFRTYY,GST";
            var appList = new List<string> {"AMOUS", "ASDFRTYY", "BAX", "BUG",  "DECIMALCP", "DUDE", "GST", "JERRYTOM", "NEWCUSTOMLOV",  "PROFILECOUNT", "PROFILEDATE", "PROFILELOV", "PROFILELOVTEST", "PROFILETRCOUNT", "PRP", "PST", "REDDY", "STANDARD", "TESTCP", "TESTCUSTOMAJAY" };
            var strList =str.Split(',').ToList();
            var k = appList.TrueForAll(p => strList.Contains(p));
        }
    }
}
