using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Практическая_4_3исип_223_Крохмаль_Коровкина.Pages;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestPage3
    {
        [TestMethod]
        public void GeneratePoints_WithX00XK3DX052_ExpectedValue()
        {
            double x0 = 0, xk = 3, dx = 0.5, b = 2;

            var expected = new[]
            { 
                (x: 0.0, y: 0.0000),
                (x: 0.5, y: 0.5000),
                (x: 1.0, y: 0.9874),
                (x: 1.5, y: 1.4340),
                (x: 2.0, y: 1.8203),
                (x: 2.5, y: 2.1332),
                (x: 3.0, y: 2.3637)
            };

            // Act
            var (points, xMin, xMax, yMin, yMax) = Page3.GeneratePoints(x0, xk, dx, b);

            // Assert
            Assert.AreEqual(expected.Length, points.Count, "Количество точек не совпадает");

            double tolerance = 0.00005;
            for (int i = 0; i < points.Count; i++)
            {
                Assert.AreEqual(expected[i].x, points[i].x, tolerance, $"x[{i}]");
                Assert.AreEqual(expected[i].y, points[i].y, tolerance, $"y[{i}]");
            }

            Assert.AreEqual(0.0, xMin, tolerance);
            Assert.AreEqual(3.0, xMax, tolerance);
            Assert.AreEqual(0.0, yMin, tolerance);
            Assert.AreEqual(2.3637, yMax, tolerance);
        }
    }
}
