using sales_taxes.basket;
using sales_taxes.money;
using sales_taxes.products;

namespace sales_taxes.recipe
{
    public class RecipeItem
    {
        public ProductName ProductName { get; }
        public Price Price { get; }
        public Quantity Quantity { get; }
        public bool IsImported { get; }

        public RecipeItem(ProductName productName, Price price, Quantity quantity, bool isImported)
        {
            ProductName = productName;
            Price = price;
            Quantity = quantity;
            IsImported = isImported;
        }
    }
}