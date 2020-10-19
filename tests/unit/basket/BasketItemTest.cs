using NUnit.Framework;
using sales_taxes.basket;
using sales_taxes.products;

namespace sales_taxes.tests.unit.basket
{
    [TestFixture]
    public class BasketItemTest
    {
        [TestCase(10, 2, 20)]
        [TestCase(0, 2, 0)]
        [TestCase(1, 10, 10)]
        [TestCase(5, 5, 25)]
        public void CalculateItemPriceNoTax(decimal price, int quantity, decimal expectedPrice)
        {
            // Arrange
            var product = new Product("", price, "0%", "0%");
            var basketItem = new BasketItem(product, quantity);
            
            // Act
            var itemPrice = basketItem.CalculatePrice();
            
            // Assert
            Assert.IsTrue(expectedPrice == itemPrice);
        }
        
        [TestCase(10, "100%", 2, 40)]
        [TestCase(10, "0%", 2, 20)]
        [TestCase(14.99, "10%", 1, 16.49)]
        [TestCase(47.50, "10%", 1, 52.25)]
        [TestCase(27.99, "15%", 2, 64.38)]
        public void CalculateItemPrice(decimal price, string tax, int quantity, decimal expectedPrice)
        {
            // Arrange
            var product = new Product("", price, tax, "0%");
            var basketItem = new BasketItem(product, quantity);
            
            // Act
            var itemPrice = basketItem.CalculatePrice();
            
            // Assert
            Assert.IsTrue(expectedPrice == itemPrice);
        }
    }
}