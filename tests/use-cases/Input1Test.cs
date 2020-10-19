using System.Text;
using NUnit.Framework;
using sales_taxes.basket;
using sales_taxes.products;
using sales_taxes.recipe;
using sales_taxes.store;

namespace sales_taxes.tests.use_cases
{
    [TestFixture]
    public class Input1Test
    {
        [TestCase]
        public void Run()
        {
            // Arrange
            var basket = Baskets
                .New()
                .Add(1, Products.Book().At(12.49M))
                .Add(1, Products.Other("music CD").At(14.99M))
                .Add(1, Products.Food("chocolate bar").At(0.85M))
                .Get();

            // Act
            var recipe = Store.Purchase(basket);
            var printedRecipe = Recipes.Print(recipe, Recipes.DefaultRecipeFormatter);

            // Assert
            var expectedRecipe = new StringBuilder()
                .AppendLine("1 book: 12.49")
                .AppendLine("1 music CD: 16.49")
                .AppendLine("1 chocolate bar: 0.85")
                .AppendLine("Sales Taxes: 1.50")
                .Append("Total: 29.83")
                .ToString();
            Assert.AreEqual(expectedRecipe, printedRecipe);
        }
    }
}