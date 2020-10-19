using System;
using NUnit.Framework;

namespace sales_taxes.tests.unit.utils
{
    [TestFixture]
    public class RoundingTest
    {
        [TestCase(1.004, 1.00)]
        [TestCase(1.005, 1.01)]
        [TestCase(1.006, 1.01)]
        [TestCase(1.12345, 1.12000)]
        [TestCase(0.99999999, 1)]
        public void RoundUpToTwoDecimalPlaces(decimal value, decimal expected)
        {
            // Act
            decimal result = Math.Round(value, 2, MidpointRounding.AwayFromZero);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestCase(12.12, 12.10)]
        [TestCase(12.13, 12.15)]
        [TestCase(12.17, 12.15)]
        [TestCase(12.18, 12.20)]
        [TestCase(0.122, 0.1)]
        [TestCase(0.125, 0.15)]
        [TestCase(0.171, 0.15)]
        [TestCase(0.1749, 0.15)]
        [TestCase(0.175, 0.2)]
        [TestCase(1, 1)]
        [TestCase(0, 0)]
        [TestCase(-1, -1)]
        [TestCase(-12.12, -12.10)]
        [TestCase(-12.13, -12.15)]
        [TestCase(-12.17, -12.15)]
        [TestCase(-12.18, -12.20)]
        [TestCase(-0.122, -0.1)]
        [TestCase(-0.125, -0.15)]
        [TestCase(-0.171, -0.15)]
        [TestCase(-0.1749, -0.15)]
        [TestCase(-0.175, -0.2)]
        public void RoundUpToNearest005(decimal d, decimal expected)
        {
            // Act
            var result = sales_taxes.utils.Math.RoundUpToNearest005(d);
            
            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}