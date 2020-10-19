using System;
using System.Text.RegularExpressions;
using sales_taxes.money.exceptions;

namespace sales_taxes.money
{
    public class Tax
    {
        private static readonly Regex _taxRegexp = new Regex(@"^(\d{1,3}(.\d{1,2})?)\%$");
        
        private readonly decimal _percentage;

        private Tax(decimal percentage)
        {
            if (!(0M <= percentage && percentage <= 1M))
                throw new InvalidTaxException($"Tax {percentage} has to be in range [0, 1]");
            _percentage = percentage;
        }

        public override bool Equals(object? obj)
        {
            var t = obj?.GetType();
            if (t != null && t != typeof(Tax))
                return false;
            return this == (Tax) obj;
        }

        public override int GetHashCode()
        {
            return _percentage.GetHashCode();
        }

        public override string ToString()
        {
            return $"{_percentage * 100M:0.00}%";
        }
        
        public static bool operator ==(Tax t1, Tax t2)
        {
            if (t1 is null && t2 is null) return true;
            if (t1 is null && !(t2 is null)) return false;
            if (!(t1 is null) && t2 is null) return false;
            
            return t1._percentage == t2._percentage;
        }
        
        public static bool operator !=(Tax t1, Tax t2)
        {
            return !(t1 == t2);
        }

        public static Tax operator +(Tax t1, Tax t2)
        {
            if (t1 is null || t2 is null)
                throw new ArgumentNullException("Cannot sum up null taxes");
            return new Tax(t1._percentage + t2._percentage);
        }

        public static Price operator *(Price p, Tax t)
        {
            return (p * t._percentage).Round();
        }
        
        public static implicit operator Tax(decimal percentage)
        {
            return new Tax(percentage / 100M);
        }
        
        public static implicit operator Tax(string percentage)
        {
            var m = _taxRegexp.Match(percentage);
            
            if (!m.Success)
                throw new TaxParsingException($"Cannot parse tax {percentage}");
            
            var p = decimal.Parse(m.Groups[1].Value);            
            return p;
        }
    }
}