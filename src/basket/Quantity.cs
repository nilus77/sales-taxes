using sales_taxes.basket.exceptions;

namespace sales_taxes.basket
{
    public class Quantity
    {
        public int Value { get; }

        private Quantity(int value)
        {
            if (value <= 0)
                throw new InvalidQuantityException("Quantity must be > 0");
            Value = value;
        }
        
        public static implicit operator Quantity(int value)
        {
            return new Quantity(value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}