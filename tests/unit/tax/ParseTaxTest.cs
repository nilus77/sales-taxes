using NUnit.Framework;
using sales_taxes.money;
using sales_taxes.money.exceptions;

namespace sales_taxes.tests.unit.tax
{
    [TestFixture]
    public class ParseTaxTest
    {
        [TestCase("1%", "1.00%")]
        [TestCase("50%", "50.00%")]
        [TestCase("100%", "100.00%")]
        public void ParseIntegralTax(string rawTaxValue, string expected)
        {
            // Act
            Tax tax = rawTaxValue;
            
            // Assert
            Assert.AreEqual(expected, tax.ToString());
        }

        [TestCase("100.100%")]
        [TestCase("0.001%")]
        [TestCase("123.123%")]
        [TestCase("10")]
        [TestCase(".10%")]
        [TestCase("-10%")]
        public void MalformedTaxThrowsParseException(string malformedTax)
        {
            // Act / Assert
            Assert.Throws<TaxParsingException>(() =>
            {
                Tax t = malformedTax;
            });
        }

        [TestCase("1000%")]
        public void InvalidTaxThrowsInvalidTaxException(string invalidTax)
        {
            // Act / Assert
            Assert.Throws<InvalidTaxException>(() =>
            {
                Tax t = invalidTax;
            });
        }
    }
}