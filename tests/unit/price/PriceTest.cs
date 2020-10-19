using NUnit.Framework;
using sales_taxes.money;
using sales_taxes.money.exceptions;

namespace sales_taxes.tests.unit.price
{
    [TestFixture]
    public class PriceTest
    {
        [TestCase(-1)]
        public void NegativePriceShouldThrowsException(decimal p)
        {
            Assert.Throws<InvalidPriceException>(() =>
            {
                var price = (Price) p;
            });
        }
        
        [TestCase(1, 1)]
        [TestCase(1.1, 1.1)]
        [TestCase(1.01, 1.01)]
        [TestCase(1.001, 1.001)]
        [TestCase(1.0001, 1.0001)]
        public void CompareEqualPrices(decimal priceValue1, decimal priceValue2)
        {
            // Arrange
            Price price1 = priceValue1;
            Price price2 = priceValue2;
            
            // Act
            var areEqual = price1 == price2;
            
            // Assert
            Assert.IsTrue(areEqual);
        }

        [TestCase(1, 2)]
        [TestCase(1.1, 1.2)]
        [TestCase(1.01, 1.02)]
        [TestCase(1.001, 1.002)]
        [TestCase(1.0001, 1.0002)]
        public void CompareDifferentPrices(decimal priceValue1, decimal priceValue2)
        {
            // Arrange
            Price price1 = priceValue1;
            Price price2 = priceValue2;
            
            // Act
            var areDifferent = price1 != price2;
            
            // Assert
            Assert.IsTrue(areDifferent);
        }

        [TestCase(1, 2, 3)]
        [TestCase(1.1, 2.2, 3.3)]
        [TestCase(1.01, 2.02, 3.03)]
        [TestCase(1.001, 2.002, 3.003)]
        [TestCase(1.0001, 2.0002, 3.0003)]
        public void SumTwoPrices(decimal priceValue1, decimal priceValue2, decimal expectedPriceValue)
        {
            // Arrange
            Price price1 = priceValue1;
            Price price2 = priceValue2;
            
            // Act
            var result = price1 + price2;
            
            // Assert
            Price expectedPrice = expectedPriceValue;
            Assert.IsTrue(result == expectedPrice);
        }

        [TestCase(1, 2, 2)]
        [TestCase(1.1234, 1, 1.1234)]
        [TestCase(2.2, 2, 4.4)]
        [TestCase(32.252, 2.4, 77.4048)]
        public void MultiplyPriceForAScalar(decimal priceValue, decimal x, decimal expectedPriceValue)
        {
            // Arrange
            Price price = priceValue;
            
            // Act
            var result = price * x;
            
            // Assert
            var expectedPrice = expectedPriceValue;
            Assert.IsTrue(result == expectedPrice);
        }

        [TestCase(1, "0%", 1)]
        [TestCase(1, "5%", 1.05)]
        [TestCase(1, "10%", 1.10)]
        [TestCase(1, "50%", 1.50)]
        [TestCase(1, "100%", 2)]
        public void AddTaxes(decimal priceValue, string taxValue, decimal expected)
        {
            // Arrange
            Price p = priceValue;
            Tax t = taxValue;
            
            // Act
            var result = p + t;
            
            // Assert
            Assert.AreEqual((Price)expected, result);
        }
    }
}