using sales_taxes.basket;
using sales_taxes.recipe;

namespace sales_taxes.store
{
    public class StoreManager
    {
        public Recipe Submit(Basket basket)
        {
            var recipe = new Recipe(basket.CalculateTotal(), basket.CalculateSalesTaxes());
            foreach (var item in basket)
            {
                var itemPrice = item.CalculatePrice();
                var recipeItem = new RecipeItem(item.Product.Name, itemPrice, item.Quantity, item.IsImported);
                recipe.AddItem(recipeItem);
            }
            return recipe;
        }
    }
}