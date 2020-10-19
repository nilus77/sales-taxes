using sales_taxes.basket;
using sales_taxes.recipe;

namespace sales_taxes.store
{
    public static class Store
    {
        public static Recipe Purchase(Basket basket)
        {
            return new StoreManager().Submit(basket);
        }
    }
}