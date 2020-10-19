using sales_taxes.money;

namespace sales_taxes.products
{
    public class Product
    {
        public ProductName Name { get; }
        public Price Price { get; }
        public Tax BasicSalesTax { get; }
        public Tax AdditionalSalesTax { get; }
        
        public Product(ProductName name, Price price, Tax basicSalesTax, Tax additionalSalesTax)
        {
            Name = name;
            Price = price;
            BasicSalesTax = basicSalesTax;
            AdditionalSalesTax = additionalSalesTax;
        }
    }
}