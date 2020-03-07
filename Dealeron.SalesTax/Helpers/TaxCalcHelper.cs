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

    public interface ITaxCalcHelper: ITaxHelperBase
    {
        decimal CalculateTaxes(decimal totalPrice, decimal taxPercentage);
    }
    public class TaxCalcHelper: ITaxCalcHelper
    {

        private List<PurchasedItem> _itemList {get; set;}
        public TaxCalcHelper()
        {

        }
       
        public decimal CalculateTaxes(decimal totalPrice, decimal taxPercentage)
        {
            return  RoundUpTaxes(totalPrice, taxPercentage);
        }

        private decimal RoundUpTaxes(decimal totalPrice, decimal taxPercentage)
        {
            var taxAmount = totalPrice * taxPercentage;
            decimal evenAmount = Convert.ToDecimal(Convert.ToInt32(taxAmount));
            decimal portionToRound = taxAmount - evenAmount;
            var roundedPortionTax =  decimal.Round(portionToRound,1, MidpointRounding.AwayFromZero);
            return evenAmount + roundedPortionTax;
        }

        private decimal SumUpTaxes()
        {
            return 0;
        }


    }
}