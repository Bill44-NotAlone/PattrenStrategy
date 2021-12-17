using Lib1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        List<double> list1 = new List<double>();
        List<double> list2 = new List<double>() { 1 };
        List<double> list3 = new List<double>() { 2, 1 };
        List<double> list4 = new List<double>() { 1, 2};
        [TestMethod]
        public void TestMethod1()
        {
            Assert.ReferenceEquals(new List<double>() {}, Class1.Pus(list1));
        }
        [TestMethod]
        public void TestMethod2()
        {
            Assert.ReferenceEquals(new List<double>() { 1 }, Class1.Pus(list2));
        }
        [TestMethod]
        public void TestMethod3()
        { 
            Assert.ReferenceEquals(new List<double>() { 1, 2 }, Class1.Pus(list3));
        }
        [TestMethod]
        public void TestMethod4()
        {
            Assert.ReferenceEquals(new List<double>() { 1, 2 }, Class1.Pus(list3));
        }
    }
}
