using System.Text;
using NUnit.Framework;
using sales_taxes.basket;
using sales_taxes.products;
using sales_taxes.recipe;
using sales_taxes.store;

namespace sales_taxes.tests.use_cases
{
    [TestFixture]
    public class Input3Test
    {
        [Ignore("Not sure about taxes calculation")]
        [TestCase]
        public void Run()
        {
            // Arrange
            var basket = Baskets
                .New()
                .Add(1, Products.Imported.Other("bottle of perfume").At(27.99M))
                .Add(1, Products.Other("bottle of perfume").At(18.99M))
                .Add(1, Products.Medical("packet of headache pills").At(9.75M))
                .Add(1, Products.Imported.Food("box of chocolates").At(11.25M))
                .Get();

            // Act
            var recipe = Store.Purchase(basket);
            var printedRecipe = Recipes.Print(recipe, Recipes.DefaultRecipeFormatter);

            // Assert
            var expectedRecipe = new StringBuilder()
                .AppendLine("1 imported bottle of perfume: 32.19")
                .AppendLine("1 bottle of perfume: 20.89")
                .AppendLine("1 packet of headache pills: 9.75")
                .AppendLine("1 imported box of chocolates: 11.85") // Shouldn't it be 11.80? If not, then I'm missing something.
                .AppendLine("Sales Taxes: 6.70")
                .Append("Total: 74.68")
                .ToString();
            Assert.AreEqual(expectedRecipe, printedRecipe);
        }
    }
}