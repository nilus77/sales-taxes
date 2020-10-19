using NUnit.Framework;
using sales_taxes.money;

namespace sales_taxes.tests.unit.tax
{
    [TestFixture]
    public class CalculateTaxTest
    {
        [TestCase]
        public void ApplyNoTax()
        {
            // Arrange
            Price originalPrice = 13.13M;
            Tax tax = "0%";

            // Act
            var newPrice = originalPrice + (originalPrice * tax);

            // Assert
            Assert.AreEqual(originalPrice, newPrice);
        }

        [TestCase]
        public void ApplyFullTax()
        {
            // Arrange
            Price originalPrice = 7.5M;
            Tax tax = "100%";
            
            // Act
            var newPrice = originalPrice + (originalPrice * tax);
            
            // Assert
            Price expectedPrice = 15M;
            Assert.AreEqual(newPrice, expectedPrice);
        }

        [TestCase(28.94, "5%", 1.45)]
        [TestCase(28.88, "5%", 1.45)]
        [TestCase(5, "5%", 0.25)]
        [TestCase(19.998, "5%", 1)]
        public void ApplyTaxAndRound(decimal priceValue, string taxValue, decimal expectedPriceValue)
        {
            // Arrange
            Price price = priceValue;
            Tax tax = taxValue;
            
            // Act
            var additionalPrice = price * tax;
            
            // Assert
            Price expectedPrice = expectedPriceValue;
            Assert.AreEqual(expectedPrice, additionalPrice);
        }
    }
}