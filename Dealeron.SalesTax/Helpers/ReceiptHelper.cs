using Dealeron.SalesTax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dealeron.SalesTax.Helpers
{
    public class ReceiptHelper : IReceiptHelper
    {

        private ITaxCalcHelper _taxHelper;
        public ReceiptViewModel ReceiptModel { get; set; }
        public ReceiptHelper()
        {
            _taxHelper = new TaxCalcHelper();
        }

        public ReceiptHelper(PurchasedItemsViewModel model)
        {
            _model = model;
            ReceiptModel = new ReceiptViewModel();
        }

        public bool ProcessReceipt()
        {
            //Group same purchased items
            _model.PurchasedItems =  GroupPurchasedItemsByDescription();
            
            //Calculate each unique items Tax percentage
            CalculateTaxPerc();

            CalculateTaxAmnt();

            ReceiptModel.PurchasedItems = _model.PurchasedItems; 
            return true;
        }

        private void CalculateTaxAmnt()
        {
            _taxHelper = new TaxCalcHelper();
            foreach (var item in _model.PurchasedItems)
            {
                item.TaxAmount = _taxHelper.CalculateTaxes(item.TotalUnitPrice, item.TaxPercentage);
                item.TotalUnitPrice += item.TaxAmount;
                ReceiptModel.TotalTaxAmount += item.TaxAmount;
                ReceiptModel.TotalAmount += item.TotalUnitPrice;
            }
        }

        private List<PurchasedItem>  GroupPurchasedItemsByDescription()
        {
            List<PurchasedItem> groupedList = new List<PurchasedItem>();
            var  groupPurchasedItems = _model.PurchasedItems
                                .GroupBy(u => u.Description)
                                .Select(grp => grp.ToList())
                                .ToList();
            foreach (var item in groupPurchasedItems)
            {
                var firstIdenticalItem = item.FirstOrDefault();
                firstIdenticalItem.Quantity = item.Count();
                firstIdenticalItem.TotalUnitPrice = firstIdenticalItem.UnitPrice* item.Count();
                groupedList.Add(firstIdenticalItem);
            }
            return groupedList;
        }

        private PurchasedItemsViewModel _model { get; set; }

        private void CalculateTaxPerc()
        {
            foreach (var item in _model.PurchasedItems)
            {
                switch (item.Category)
                {
                    case ItemCategory.Book:
                        break;
                    case ItemCategory.Food:
                        break;
                    case ItemCategory.Medical:
                        break;
                    case ItemCategory.Other:
                        item.TaxPercentage += 0.10m;
                        break;
                    default:
                        break;
                }

                if (item.ImportProduct)
                {
                    item.TaxPercentage += 0.05m;
                }
            }

        }
    }

    public interface IReceiptHelper
    {
        bool ProcessReceipt();

        ReceiptViewModel ReceiptModel { get; set; }
    }
}