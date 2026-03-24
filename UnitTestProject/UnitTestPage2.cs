using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Практическая_4_3исип_223_Крохмаль_Коровкина.Pages;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestPage2
    {
        [TestMethod]
        public void CalculateFunction_WithX5Q9_ExpFunction_ReturnsExpected()
        {
            double x = 5;
            double q = 9;
            string functionType = "exp";
            double expected = 5.0589; 

            // Act
            double actual = Page2.CalculateFunction(x, q, functionType);

            // Assert
            Assert.AreEqual(expected, actual, 0.0001, "Результат вычисления не совпадает с ожидаемым.");
        }
    }
}
