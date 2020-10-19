using NUnit.Framework;
using sales_taxes.money;

namespace sales_taxes.tests.unit.tax
{
    [TestFixture]
    public class TaxOperationTest
    {
        [TestCase("50%", "50%", "100%")]
        public void SumTwoTaxes(string t1, string t2, string expected)
        {
            // Arrange
            Tax tax1 = t1;
            Tax tax2 = t2;
            
            // Act
            var result = tax1 + tax2;

            // Assert
            Assert.AreEqual((Tax)expected, result);
        }
    }
}