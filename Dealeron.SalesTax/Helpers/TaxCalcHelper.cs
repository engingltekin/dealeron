using Dealeron.SalesTax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dealeron.SalesTax.Helpers
{
    public interface ITaxHelperBase
    {

    }

    public interface ITaxCalcHelper : ITaxHelperBase
    {
        decimal CalculateTaxes(decimal unitPrice, decimal taxPercentage, int quantity);
    }
    public class TaxCalcHelper : ITaxCalcHelper
    {

        private List<PurchasedItem> _itemList { get; set; }
        public TaxCalcHelper()
        {

        }

        public decimal CalculateTaxes(decimal totalPrice, decimal taxPercentage, int quantity)
        {
            return RoundUpTaxes(totalPrice, taxPercentage, quantity);
        }

        private decimal RoundUpTaxes(decimal unitPrice, decimal taxPercentage, int quantity)
        {
            var unitTaxAmount = unitPrice * taxPercentage;
            var roundedPortionTax = decimal.Round(unitTaxAmount, 2);
            var intTaxAmount = Convert.ToInt32(roundedPortionTax * 100);
            int lastDigit = intTaxAmount % 10;
            if (lastDigit == 0)
            {
                roundedPortionTax = intTaxAmount * 0.01m;
            }
            else if (lastDigit > 5)
            {
                intTaxAmount += (10 - lastDigit);
                roundedPortionTax = intTaxAmount * 0.01m;
            }
            else
            {
                intTaxAmount += (5 - lastDigit);
                roundedPortionTax = intTaxAmount * 0.01m;
            }

            return roundedPortionTax * quantity;
        }

        private decimal SumUpTaxes()
        {
            return 0;
        }


    }
}