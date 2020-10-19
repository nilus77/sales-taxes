using sales_taxes.basket.builders;

namespace sales_taxes.basket
{
    public static class Baskets
    {
        public static BasketBuilder New()
        {
            return new BasketBuilder().New();
        }
    }
}