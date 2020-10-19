using sales_taxes.products.builders;

namespace sales_taxes.products
{
    public static class Products
    {
        public static ProductBuilder Imported => new ProductBuilder().PlusAdditionalTax("5%");

        public static IProductBuilderPriceOnly Book(string name = "book")
        {
            return new ProductBuilder()
                .PlusBasicTax("0%")
                .Book(name);
        }

        public static IProductBuilderPriceOnly Food(string name)
        {
            return new ProductBuilder()
                .PlusBasicTax("0%")
                .Food(name);
        }

        public static IProductBuilderPriceOnly Medical(string name)
        {
            return new ProductBuilder()
                .PlusBasicTax("0%")
                .Medical(name);
        }
        
        public static ProductBuilder Other(string name)
        {
            return new ProductBuilder()
                .SetName(name)
                .PlusBasicTax("10%");
        }
    }
}