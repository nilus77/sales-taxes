using NUnit.Framework;
using sales_taxes.basket;

namespace sales_taxes.tests.unit.basket
{
    [TestFixture]
    public class BasketTest
    {
        [TestCase]
        public void AddOneItemTest()
        {
            // Arrange
            var basket = new Basket();
            
            // Act
            basket.AddItem(new BasketItem(null, 1));
            
            // Assert
            Assert.AreEqual(1, basket.Count());
        }
        
        [TestCase]
        public void AddOneItemAndQuantityTest()
        {
            // Arrange
            var basket = new Basket();
            
            // Act
            basket.AddItem(new BasketItem(null, 3));
            
            // Assert
            Assert.AreEqual(3, basket.Count());
        }
        
        [TestCase]
        public void AddSeveralItemsAndQuantityTest()
        {
            // Arrange
            var basket = new Basket();
            
            // Act
            basket.AddItem(new BasketItem(null, 3));
            basket.AddItem(new BasketItem(null, 1));
            basket.AddItem(new BasketItem(null, 3));
            
            // Assert
            Assert.AreEqual(7, basket.Count());
        }
    }
}