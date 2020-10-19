using System;
using NUnit.Framework;
using sales_taxes.basket;
using sales_taxes.money;

namespace sales_taxes.tests.unit.price
{
    [TestFixture]
    public class PriceQuantityOperationsTest
    {
        [TestCase(1, 5, 5)]
        [TestCase(1.01, 5, 5.05)]
        [TestCase(1.001, 5, 5.005)]
        [TestCase(1.0001, 5, 5.0005)]
        public void PriceTimesQuantity(decimal p, int q, decimal expected)
        {
            // Arrange
            Price price = p;
            Quantity quantity = q;
            
            // Act
            Price result = p * q;
            
            // Assert
            Assert.AreEqual(result, (Price)expected);
        }

        [TestCase]
        public void MultiplyNullQuantityThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var p = (Price) 10M * (Quantity) null;
            });
        }
        
        [TestCase]
        public void MultiplyNullPriceThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var p = (Price) null * (Quantity) 1;
            });
        }
    }
}