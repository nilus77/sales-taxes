using System;
using sales_taxes.basket;
using sales_taxes.money.exceptions;

namespace sales_taxes.money
{
    public class Price
    {
        private readonly decimal _value;

        private Price(decimal value)
        {
            if (value < 0)
                throw new InvalidPriceException("Price cannot be negative");
            _value = value;
        }

        public Price Round()
        {
            return new Price(utils.Math.RoundUpToNearest005(_value));
        }

        public override bool Equals(object? obj)
        {
            var t = obj?.GetType();
            if (t != null && t != typeof(Price))
                return false;
            return this == (Price) obj;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
        
        public override string ToString()
        {
            return $"{_value:0.00}";
        }

        public static bool operator ==(Price p1, Price p2)
        {
            if (p1 is null && p2 is null) return true;
            if (p1 is null && !(p2 is null)) return false;
            if (!(p1 is null) && p2 is null) return false;
            
            return p1._value == p2._value;
        }
        
        public static bool operator !=(Price p1, Price p2)
        {
            return !(p1 == p2);
        }

        public static Price operator +(Price p1, Price p2)
        {
            if (p1 is null || p2 is null)
                throw new ArgumentNullException("Cannot sum up null prices");
            return new Price(p1._value + p2._value);
        }

        public static Price operator +(Price p, Tax t)
        {
            if (p is null)
                throw new ArgumentNullException("Price cannot be null");
            if (t is null)
                throw new ArgumentNullException("Tax cannot be null");
            var taxValue = p * t;
            return p + taxValue;
        }

        public static Price operator *(Price p, decimal x)
        {
            if (p is null)
                throw  new ArgumentNullException("Cannot multiply null price");
            return new Price(p._value * x);
        }
        
        public static Price operator *(Price p, int x)
        {
            if (p is null)
                throw  new ArgumentNullException("Cannot multiply null price");
            return p * (decimal) x;
        }
        
        public static Price operator *(Price p, Quantity q)
        {
            if (p is null)
                throw  new ArgumentNullException("Cannot multiply null price");
            if (q is null)
                throw  new ArgumentNullException("Cannot multiply null quantity");
            return p * q.Value;
        }
        
        public static implicit operator Price(decimal x)
        {
            return new Price(x);
        }
    }
}