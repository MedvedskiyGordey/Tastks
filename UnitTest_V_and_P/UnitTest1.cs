using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;

namespace UnitTest_V_and_P
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodVector()
        {
            Vector vector1 = new Vector(13.2, 15.4, 16.9);
            Vector vector2 = new Vector(0, 35.6, 41.3);
            Vector sum = new Vector(13.2, 51, 58.2);
            Vector dif = new Vector(13.2, -20.2, -24.4);
            Vector Vec = new Vector(34.38, -545.16, 469.92);
            double Scalar = 1246.21;
            Assert.IsTrue((vector1 + vector2) == sum);
            Assert.IsTrue((vector1 - vector2) == dif);
            Assert.IsTrue((vector1 % vector2) == Vec);
            Assert.AreEqual(vector1 * vector2, Scalar);
        }

        [TestMethod]
        public void PolinomOperations()
        {
            Polinom p1 = new Polinom(new double[] { 17.3, 16.2, 6, 3 });
            Polinom p2 = new Polinom(new double[] { 5, -4.9, 13.7, 3, 5 });
            Polinom sum = new Polinom(new double[] { 5, 12.4, 29.9, 9, 8 });
            Polinom dif = new Polinom(new double[] { -5, 22.2, 2.5, 3, -2 });
            Polinom mult = new Polinom(new double[] { 5, 39, 140.1, 202.6, 259.44, 187.63, -3.77, 86.5 });
            Assert.IsTrue((p1 + p2) == sum);
            Assert.IsTrue((p1 - p2) == dif);
            Assert.IsTrue((p1 * p2) == mult);
        }
    }
}
