using NUnit.Framework;
using sales_taxes.basket;
using sales_taxes.products;

namespace sales_taxes.tests.unit.basket
{
    [TestFixture]
    public class BasketBuilderTest
    {
        [TestCase]
        public void BuildEmptyBasket()
        {
            // Act
            var basket = Baskets.New().Get();
            
            // Assert
            Assert.IsNotNull(basket);
        }

        [TestCase]
        public void BuildOneProductBasket()
        {
            // Arrange / Act
            var basket = Baskets
                .New()
                .Add(1, Products.Imported.Book().At(0))
                .Get();
            
            // Assert
            Assert.AreEqual(1, basket.Count());
        }

        [TestCase]
        public void BuildBasketHavingManyProducts()
        {
            // Arrange / Act
            var basket = Baskets
                .New()
                .Add(1, Products.Book().At(1))
                .Add(10, Products.Book().At(2))
                .Add(6, Products.Book().At(3))
                .Get();
            
            // Assert
            Assert.AreEqual(17, basket.Count());
        }
    }
}