using sales_taxes.products;
using sales_taxes.products.builders;

namespace sales_taxes.basket.builders
{
    public class BasketBuilder
    {
        private Basket _basket;
        
        public BasketBuilder New()
        {
            _basket = new Basket();
            return this;
        }
        
        public BasketBuilder Add(int quantity, ProductBuilder product)
        {
            _basket.AddItem(new BasketItem(product.Build(), quantity));
            return this;
        }
        
        public Basket Get()
        {
            return _basket;
        }
    }
}