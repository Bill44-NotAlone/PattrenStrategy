using Lib1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        List<double> listTR11 = new List<double>();
        List<double> listTR12 = new List<double>() { 1 };
        List<double> listTR21 = new List<double>() { 1, 2 };
        List<double> listTR31 = new List<double>() { 2, 1, 4, 3 };
        List<double> listTR32 = new List<double>() { 7, 2, 1, 7, 3, 6, 7 };
        [TestMethod]
        public void TestMethodTR11()
        {
            Assert.ReferenceEquals(new List<double>() { }, Class1.Pus(listTR11));
        }
        [TestMethod]
        public void TestMethodTR12()
        {
            Assert.ReferenceEquals(new List<double>() { 1 }, Class1.Pus(listTR12));
        }
        [TestMethod]
        public void TestMethodTR21()
        {
            Assert.ReferenceEquals(new List<double>() { 1, 2 }, Class1.Pus(listTR21));
        }
        [TestMethod]
        public void TestMethodTR31()
        {
            Assert.ReferenceEquals(new List<double>() { 1, 2, 3, 4 }, Class1.Pus(listTR31));
        }
        public void TestMethodTR32()
        {
            Assert.ReferenceEquals(new List<double>() { 1, 2, 3, 6, 7, 7, 7}, Class1.Pus(listTR32));
        }
    }
}
