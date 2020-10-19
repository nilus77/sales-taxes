using System;

namespace sales_taxes.basket.exceptions
{
    public class InvalidQuantityException : Exception
    {
        public InvalidQuantityException(string msg)
            : base(msg)
        {
        }
    }
}