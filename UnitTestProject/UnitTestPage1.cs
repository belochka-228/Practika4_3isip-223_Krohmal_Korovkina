using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestPage1
    {
        public static double Calculate(double x, double y, double z)
        {
            double sinZ = Math.Sin(z);
            if (Math.Abs(sinZ) < 1e-10)
                throw new DivideByZeroException("sin(z) не должен быть равен нулю.");

            double term1 = Math.Pow(2, -x);
            double absY = Math.Abs(y);
            double root4Y = Math.Pow(absY, 1.0 / 4.0);
            double exponent = (x - 1) / sinZ;
            double expValue = Math.Exp(exponent);
            double root3Exp = Math.Pow(expValue, 1.0 / 3.0);
            double underSqrt = x + root4Y * root3Exp;

            if (underSqrt < 0)
                throw new ArgumentOutOfRangeException(nameof(underSqrt), "Подкоренное выражение отрицательно.");

            return term1 * Math.Sqrt(underSqrt);
        }
        [TestMethod]
        public void Calculate_WithX1Y6Z3_ReturnsExpected()
        {
            double x = 1;
            double y = 6;
            double z = 3;
            double expected = 0.8008;

            double actual = Calculate(x, y, z);

            Assert.AreEqual(expected, actual, 0.0001, "Результат вычисления не совпадает с ожидаемым.");
        }
    }
}
