using Dealeron.SalesTax.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dealeron.SalesTax.Helpers
{
    public static class FormHelpers
    {
        public static readonly string DefaultValue = "0";
        public static readonly string DefaultDropDownOption = "--";
        public static SelectList GetItemCategoryValues()
        {
            return new SelectList(new List<SelectListItem>()
            {
                new SelectListItem { Text = DefaultDropDownOption, Value = "0"},
                new SelectListItem() { Text = ItemCategory.Book.GetDisplayName(), Value= ((int)ItemCategory.Book).ToString()},
                new SelectListItem() { Text = ItemCategory.Food.GetDisplayName(), Value=((int)ItemCategory.Food).ToString()},
                new SelectListItem() { Text = ItemCategory.Medical.GetDisplayName(), Value=((int)ItemCategory.Medical).ToString()}
            }, "Value", "Text");
        }
    }
}