using Dealeron.SalesTax.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Dealeron.SalesTax.Models
{
    public class PurchasedItem
    {
        [Display(Name = "Description", ResourceType = typeof(Resources.Resource))]
        public string Description { get; set; }

        [Display(Name = "Import", ResourceType = typeof(Resources.Resource))]
        public bool ImportProduct { get; set; }

        [Display(Name = "Price", ResourceType = typeof(Resources.Resource))]
        public decimal UnitPrice { get; set; }

        public ItemCategory Category { get; set; }

        public decimal TaxPercentage { get; set; }

        public decimal TotalTaxAmount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal TotalUnitPrice { get; set; }

        public int Quantity { get; set; }


    }
}