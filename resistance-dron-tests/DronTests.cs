using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using resistance_dron;

namespace resistance_dron_tests
{
    [TestClass]
    public class DronTests
    {
        [TestMethod]
        public void maxNumberLaserCannons_NumberConnons4_NumberConnonsCalculated()
        {
            Dron resistanceDron = new Dron();
            int numberConnons = 0;
            int expected = 4;
            int[] A = { 1, 6, 4, 5, 4, 5, 1, 2, 3, 4, 7, 2 };
            string message = "";

            numberConnons = resistanceDron.maxNumberLaserCannons(A);

            message = String.Format("Incorretly maximum connons number -> expected: {0}, actual: {1}", expected.ToString(), numberConnons.ToString());

            Assert.AreEqual(expected, numberConnons, message);
        }
    }
}
