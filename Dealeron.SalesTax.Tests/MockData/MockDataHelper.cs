using Dealeron.SalesTax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealeron.SalesTax.Tests
{
    public class MockDataHelper
    {
        public List<PurchasedItem> ImportedPurchasedItems
        {
            get { return GetImportedPurchasedItems(); }
        }
        private List<PurchasedItem> GetImportedPurchasedItems()
        {
            return new List<PurchasedItem>()
            {
                new PurchasedItem() { Description ="Imported bottle of perfume", Category = Helpers.ItemCategory.Other, ImportProduct=true, UnitPrice=27.99m },
            };
        }
    }
}
