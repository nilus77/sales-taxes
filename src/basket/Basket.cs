using System.Collections;
using System.Collections.Generic;
using System.Linq;
using sales_taxes.money;

namespace sales_taxes.basket
{
    public class Basket : IEnumerable<BasketItem>
    {
        private readonly List<BasketItem> _items;

        public Basket()
        {
            _items = new List<BasketItem>();
        }

        public void AddItem(BasketItem item)
        {
            _items.Add(item);
        }

        public Price CalculateTotal()
        {
            return _items.Aggregate<BasketItem, Price>(0M, (current, item) => current + item.CalculatePrice());
        }

        public Price CalculateSalesTaxes()
        {
            return _items.Aggregate<BasketItem, Price>(0M, (current, item) => current + item.CalculateSalesTax());
        }
        
        public IEnumerator<BasketItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }

    public static class BasketExtensions
    {
        public static int Count(this IEnumerable<BasketItem> basket)
        {
            var result = 0;
            foreach (var item in basket)
            {
                result += item.Quantity.Value;
            }
            return result;
        }
    }
}