using System.Text;
using NUnit.Framework;
using sales_taxes.basket;
using sales_taxes.products;
using sales_taxes.recipe;
using sales_taxes.store;

namespace sales_taxes.tests.use_cases
{
    [TestFixture]
    public class Input2Test
    {
        [TestCase]
        public void Run()
        {
            // Arrange
            var basket = Baskets
                .New()
                .Add(1, Products.Imported.Food("box of chocolates").At(10M))
                .Add(1, Products.Imported.Other("bottle of perfume").At(47.50M))
                .Get();

            // Act
            var recipe = Store.Purchase(basket);
            var printedRecipe = Recipes.Print(recipe, Recipes.DefaultRecipeFormatter);

            // Assert
            var expectedRecipe = new StringBuilder()
                .AppendLine("1 imported box of chocolates: 10.50")
                .AppendLine("1 imported bottle of perfume: 54.65")
                .AppendLine("Sales Taxes: 7.65")
                .Append("Total: 65.15")
                .ToString();
            Assert.AreEqual(expectedRecipe, printedRecipe);
        }
    }
}