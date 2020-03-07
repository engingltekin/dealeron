using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dealeron.SalesTax.Models
{
    public class PurchasedItemsViewModel
    {
        public PurchasedItemsViewModel()
        {
            PurchasedItems = GetDefaultPurchasedItems();
        }

        private List<PurchasedItem> GetDefaultPurchasedItems()
        {
            return new List<PurchasedItem>()
            {
                new PurchasedItem() { Description ="Imported bottle of perfume", Category = Helpers.ItemCategory.Other, ImportProduct=true, UnitPrice=27.99m },
             new PurchasedItem() { Description ="Bottle of perfume", Category = Helpers.ItemCategory.Other, ImportProduct=false, UnitPrice=18.99m },
             new PurchasedItem() { Description ="Packet of headache pills", Category = Helpers.ItemCategory.Medical, ImportProduct=false, UnitPrice=9.75m },
             new PurchasedItem() { Description ="Imported box of chocolates", Category = Helpers.ItemCategory.Food, ImportProduct=true, UnitPrice=11.25m },
             new PurchasedItem() { Description ="Imported box of chocolates", Category = Helpers.ItemCategory.Food, ImportProduct=true, UnitPrice=11.25m },
            };
        }

        public List<PurchasedItem> PurchasedItems { get; set; }
    }

    public class ReceiptViewModel
    {
        public ReceiptViewModel()
        {
            PurchasedItems = new List<PurchasedItem>();
        }
        public List<PurchasedItem> PurchasedItems { get; set; }

        public decimal TotalTaxAmount { get; set; }

        public decimal TotalAmount { get; set; }
    }
}