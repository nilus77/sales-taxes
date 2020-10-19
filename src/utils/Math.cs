using System;

namespace sales_taxes.utils
{
    public static class Math
    {
        public static decimal RoundUpToNearest005(decimal d)
        {
            var originalD = d;
            d = System.Math.Abs(d);
            d = System.Math.Round(d, 2, MidpointRounding.AwayFromZero);
            var iPart = (int)d;
            var fPart = (int)((d - iPart) * 100M);
            var firstDecimal = (int) (fPart / 10M);
            var secondDecimal = fPart - firstDecimal * 10;
            var result = iPart + firstDecimal / 10M;
            if (3 <= secondDecimal && secondDecimal <= 7) 
                result += 0.05M;
            if (secondDecimal > 7)
                result += 0.1M;
            if (originalD < 0)
                result *= -1M;
            return result;
        }
    }
}