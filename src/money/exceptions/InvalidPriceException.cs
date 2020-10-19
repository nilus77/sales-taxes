using System;

namespace sales_taxes.money.exceptions
{
    public class InvalidPriceException : Exception
    {
        public InvalidPriceException(string msg)
            : base(msg)
        {
        }
    }
}