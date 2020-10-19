namespace sales_taxes.products
{
    public class ProductName
    {
        private readonly string _name;

        private ProductName(string name)
        {
            _name = name;
        }

        public static implicit operator ProductName(string name)
        {
            return new ProductName(name);
        }

        public override string ToString()
        {
            return _name;
        }
    }
}