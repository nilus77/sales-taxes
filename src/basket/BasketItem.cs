using sales_taxes.money;
using sales_taxes.products;

namespace sales_taxes.basket
{
    public class BasketItem
    {
        public Product Product { get; }
        public Quantity Quantity { get; }
        public bool IsImported => Product.AdditionalSalesTax != "0%";
        public BasketItem(Product product, Quantity quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        
        public Price CalculatePrice()
        {
            var taxes = Product.BasicSalesTax + Product.AdditionalSalesTax;
            return Product.Price * Quantity + taxes;
        }

        public Price CalculateSalesTax()
        {
            return Product.Price * Quantity * (Product.BasicSalesTax + Product.AdditionalSalesTax);
        }
    }
}