using sales_taxes.money;

namespace sales_taxes.products.builders
{
    public interface IProductBuilderPriceOnly
    {
        public ProductBuilder At(decimal price);
    }
    
    public class ProductBuilder : IProductBuilderPriceOnly
    {
        private ProductName _name;
        private Price _price;
        private Tax _basicTax;
        private Tax _additionalTax;

        public ProductBuilder()
        {
            _name = "";
            _price = 0M;
            _basicTax = "0%";
            _additionalTax = "0%";
        }

        public IProductBuilderPriceOnly Book(string name = "book")
        {
            return SetName(name);
        }
        
        public IProductBuilderPriceOnly Food(string name)
        {
            return SetName(name);
        }
        
        public IProductBuilderPriceOnly Medical(string name)
        {
            return SetName(name);
        }
        
        public IProductBuilderPriceOnly Other(string name)
        {
            return SetName(name).PlusBasicTax("10%");
        }
        
        public ProductBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public ProductBuilder At(decimal price)
        {
            _price = price;
            return this;
        }

        public ProductBuilder PlusBasicTax(string basicTax)
        {
            _basicTax = basicTax;
            return this;
        }
        
        public ProductBuilder PlusAdditionalTax(string additionalTax)
        {
            _additionalTax = additionalTax;
            return this;
        }
        
        public Product Build()
        {
            return new Product(_name, _price, _basicTax, _additionalTax);
        }
    }
}