using System.Collections;
using System.Collections.Generic;
using sales_taxes.money;
using sales_taxes.recipe.printers;

namespace sales_taxes.recipe
{
    public class Recipe : IEnumerable<RecipeItem>
    {
        private readonly List<RecipeItem> _items;
        public Price SalesTaxes { get; }
        public Price Total { get; }

        public Recipe(Price total, Price salesTaxes)
        {
            Total = total;
            SalesTaxes = salesTaxes;
            _items = new List<RecipeItem>();
        }

        public void AddItem(RecipeItem item)
        {
            _items.Add(item);
        }
        
        public string ToString(IRecipeFormatter formatter)
        {
            return formatter.Format(this);
        }

        public IEnumerator<RecipeItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}