using System;

namespace sales_taxes.money.exceptions
{
    public class TaxParsingException : Exception
    {
        public TaxParsingException(string msg)
            : base(msg)
        {
        }
    }
}