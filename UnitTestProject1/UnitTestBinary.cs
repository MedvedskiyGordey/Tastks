﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace UnitTestBinary
{
    [TestClass]
    public class UnitTestBinary
    {
        public void Test(int a, int b, int nod)
        {
            NOD res = new NOD(a, b);
            int ans = res.BinaryEuclid(a, b);
            Assert.AreEqual(nod, ans);
        }


        [TestMethod]
        public void TestMethod1()
        {
            int a = 322328;
            int b = 122120;
            int nod = 344;
            Test(a, b, nod);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int a = 300181;
            int b = 223744;
            int nod = 19;
            Test(a, b, nod);
        }
    }
}