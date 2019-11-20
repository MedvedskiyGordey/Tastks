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
            Vector dif = new Vector(13.2, -20.2, -14.7);
            Vector Vec = new Vector(34.38, -545.16, 469.92);
            double Scalar = 1246.21;
            //Assert.IsTrue((vector1 + vector2) == sum);
            //Assert.IsTrue((vector1 - vector2) == dif);
            //Assert.IsTrue((vector1 % vector2) == Vec);
            Assert.AreEqual(vector1 * vector2, Scalar);
        }
    }
}
