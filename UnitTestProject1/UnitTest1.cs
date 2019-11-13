using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1;

namespace UnitTest1
{
    [TestClass]
    public class UnitTest1
    {
        public void Test(int a, int b, int nod)
        {
            int ans = NOD.EuclidAlg(a, b);

            Assert.AreEqual(nod, ans);
        }

        public void TestOverloading(int[] array, int nod)
        {
            int ans = NOD.EuclidAlg(array);

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

        [TestMethod]
        public void TestOverloadingMethod1()
        {
            int[] array = { 585, 81, 189};
            int nod = 9;
            TestOverloading(array, nod);
        }

        [TestMethod]
        public void TestOverloadingMethod2()
        {
            int[] array = { 78, 294, 570, 36 };
            int nod = 6;
            TestOverloading(array, nod);
        }

        [TestMethod]
        public void TestOverloadingMethod3()
        {
            int[] array = { 78, 294, 570, 36, 156 };
            int nod = 6;
            TestOverloading(array, nod);
        }
    }
}
