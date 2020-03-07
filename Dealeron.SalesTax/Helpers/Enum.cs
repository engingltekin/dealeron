using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dealeron.SalesTax.Helpers
{
    public class Enums
    {
    }

    public enum ItemCategory
    {
        [Display(Name = "Book", ResourceType = typeof(Resources.Resource))]
        Book = 1,

        [Display(Name = "Food", ResourceType = typeof(Resources.Resource))]
        Food = 2,

        [Display(Name = "Medical", ResourceType = typeof(Resources.Resource))]
        Medical = 3,

        Other = 4
    }

    public enum TaxCategory
    {
        BasicTac = 10,
        ImportTax = 5,
        BasicPlusImportTax = 15
    }
}