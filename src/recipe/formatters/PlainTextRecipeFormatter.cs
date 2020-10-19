using System.Text;

namespace sales_taxes.recipe.printers
{
    public class PlainTextRecipeFormatter : IRecipeFormatter
    {
        public string Format(Recipe recipe)
        {
            var sb = new StringBuilder();
            foreach (var item in recipe)
            {
                var imported = item.IsImported ? " imported" : string.Empty;
                sb.AppendLine($"{item.Quantity}{imported} {item.ProductName}: {item.Price}");
            }
            sb.AppendLine($"Sales Taxes: {recipe.SalesTaxes}");
            sb.Append($"Total: {recipe.Total}");
            return sb.ToString();
        }
    }
}