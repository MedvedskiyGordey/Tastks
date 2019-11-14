using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        public void TestBinary(int a, int b, int nod)
        {
            int ans = NOD.BinaryEuclid(a, b);
            Assert.AreEqual(nod, ans);
        }

        [TestMethod]
        public void TestMethod1()
        {
            int a = 322328;
            int b = 122120;
            int nod = 344;
            int ans = NOD.EuclidAlg(a, b);

            Assert.AreEqual(nod, ans);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int a = 300181;
            int b = 223744;
            int nod = 19;
            int ans = NOD.EuclidAlg(a, b);

            Assert.AreEqual(nod, ans);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int a = 585;
            int b = 81;
            int c = 189;
            int nod = 9;
            int ans = NOD.EuclidAlg(a, b, c);

            Assert.AreEqual(nod, ans);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int a = 78;
            int b = 294;
            int c = 570;
            int d = 36;
            int nod = 6;
            int ans = NOD.EuclidAlg(a, b, c, d);

            Assert.AreEqual(nod, ans);
        }

        [TestMethod]
        public void TestMethod5()
        {
            int a = 78;
            int b = 294;
            int c = 570;
            int d = 36;
            int e = 156;
            int nod = 6;
            int ans = NOD.EuclidAlg(a, b, c, d, e);

            Assert.AreEqual(nod, ans);
        }

        [TestMethod]
        public void TestMethodBinary1()
        {
            int a = 322328;
            int b = 122120;
            int nod = 344;
            TestBinary(a, b, nod);
        }

        [TestMethod]
        public void TestMethodBinary2()
        {
            int a = 300181;
            int b = 223744;
            int nod = 19;
            TestBinary(a, b, nod);
        }
    }
}
