using NUnit.Framework;
using sales_taxes.basket;
using sales_taxes.basket.exceptions;

namespace sales_taxes.tests.unit.basket
{
    [TestFixture]
    public class QuantityTest
    {
        [TestCase(1)]
        [TestCase(1000)]
        public void CreateNewQuantity(int value)
        {
            // Act
            Quantity q = value;
            
            // Assert
            Assert.AreEqual(q.Value, value);
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void NonPositiveQuantityNotAllowed(int value)
        {
            // Act / Assert
            Assert.Throws<InvalidQuantityException>(() =>
            {
                Quantity q = value;
            });
        }
    }
}