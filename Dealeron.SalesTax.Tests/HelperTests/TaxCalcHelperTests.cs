using Dealeron.SalesTax.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealeron.SalesTax.Tests.HelperTests
{
    [TestClass]
    public class TaxCalcHelperTests
    {
        private ITaxCalcHelper _taxHelper;
        private const decimal _evenTaxAmount = 0.60m;
        private const decimal _greaterThenFiveTaxAmount = 2.72m;
        private const decimal _equalToFiveTaxAmount = 2.70m;
        private const decimal _lessThenFiveTaxAmount = 2.64m;
        private const decimal _taxPercentage = 0.5m;
        [TestInitialize]
        public void TestSetup()
        {
            _taxHelper = new TaxCalcHelper();
        }

        [TestMethod]
        public void RoundUpTaxesWithEvenNumber()
        {
            decimal RoundedEvenTax = _taxHelper.CalculateTaxes(_evenTaxAmount, _taxPercentage, 2);
            var expectedResult = (_evenTaxAmount * _taxPercentage) * 2;
            // Then 
            Assert.AreEqual(expectedResult, RoundedEvenTax);
        }

        [TestMethod]
        public void RoundUpTaxesWithGreaterThenFive()
        {
            decimal RoundedGreaterTax = _taxHelper.CalculateTaxes(_greaterThenFiveTaxAmount, _taxPercentage, 2);
            var expectedResult = 2.80m;
            // Then 
            Assert.AreEqual(expectedResult, RoundedGreaterTax);
        }

        [TestMethod]
        public void RoundUpTaxesWithLessThenFive()
        {
            decimal RoundedLessTax = _taxHelper.CalculateTaxes(_lessThenFiveTaxAmount, _taxPercentage, 2);
            var expectedResult = 2.70m;
            // Then 
            Assert.AreEqual(expectedResult, RoundedLessTax);
        }

        [TestMethod]
        public void RoundUpTaxesWithEqualToFive()
        {
            decimal RoundedLessTax = _taxHelper.CalculateTaxes(_equalToFiveTaxAmount, _taxPercentage, 2);
            var expectedResult = 2.70m;
            // Then 
            Assert.AreEqual(expectedResult, RoundedLessTax);
        }
    }
}
