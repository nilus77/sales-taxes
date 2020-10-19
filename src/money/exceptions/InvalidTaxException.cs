using System;

namespace sales_taxes.money.exceptions
{
    public class InvalidTaxException : Exception
    {
        public InvalidTaxException(string msg)
            : base(msg)
        {
        }
    }
}