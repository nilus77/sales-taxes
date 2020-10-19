using sales_taxes.recipe.printers;

namespace sales_taxes.recipe
{
    public static class Recipes
    {
        public static readonly IRecipeFormatter DefaultRecipeFormatter = new PlainTextRecipeFormatter();
        
        public static string Print(Recipe recipe, IRecipeFormatter formatter)
        {
            return recipe.ToString(formatter);
        }
    }
}