using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Практическая_4_3исип_223_Крохмаль_Коровкина.Pages;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestPage1
    {
        [TestMethod]
        public void Calculate_WithX1Y6Z3_ReturnsExpected()
        {
            double x = 1;
            double y = 6;
            double z = 3;
            double expected = 0.8008;

            // Act
            double actual = Page1.CalculateFunction(x, y, z);

            // Assert
            Assert.AreEqual(expected, actual, 0.0001, "Результат вычисления не совпадает с ожидаемым.");
        }
    }
}
