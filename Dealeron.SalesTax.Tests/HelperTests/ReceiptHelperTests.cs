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
    public class ReceiptHelperTests
    {
        private IReceiptHelper _receiptHelper;
        private List<Models.PurchasedItem> _importedTestItems;
        private MockDataHelper _mockData;
        private const decimal _importTax = 0.05m;
        private const decimal _basicTax = 0.1m;
 
        [TestInitialize]
        public void TestSetup()
        {
            _mockData = new MockDataHelper();
            _receiptHelper = new ReceiptHelper();
            _importedTestItems = _mockData.ImportedPurchasedItems;
        }

        [TestMethod]
        public void ItemCategoryTaxCalcForOtherImportedandBasicTax()
        {
            _importedTestItems.ForEach(x => x.Category = ItemCategory.Other);
            Models.PurchasedItem purchasedItem = ProcessReceipt();
            Assert.AreEqual(0.15m, purchasedItem.TaxPercentage);
        }

        [TestMethod]
        public void ItemCategoryTaxCalcForBookrImported()
        {
            _importedTestItems.ForEach(x => x.Category = ItemCategory.Book);
            Models.PurchasedItem purchasedItem = ProcessReceipt();
            Assert.AreEqual(0.05m, purchasedItem.TaxPercentage);
        }

        [TestMethod]
        public void ItemCategoryTaxCalcForFoodImported()
        {
            _importedTestItems.ForEach(x => x.Category = ItemCategory.Food);
            Models.PurchasedItem purchasedItem = ProcessReceipt();
            Assert.AreEqual(0.05m, purchasedItem.TaxPercentage);
        }

        [TestMethod]
        public void ItemCategoryTaxCalcForMedicalImported()
        {
            _importedTestItems.ForEach(x => x.Category = ItemCategory.Medical);
            Models.PurchasedItem purchasedItem = ProcessReceipt();
            Assert.AreEqual(0.05m, purchasedItem.TaxPercentage);
        }

        [TestMethod]
        public void ItemCategoryTaxCalcForOtherNotImported()
        {
            _importedTestItems.ForEach(x => { x.Category = ItemCategory.Other; x.ImportProduct = false; });
            Models.PurchasedItem purchasedItem = ProcessReceipt();
            Assert.AreEqual(0.1m, purchasedItem.TaxPercentage);
        }
        [TestMethod]
        public void ItemCategoryTaxCalcForMedicalNotImported()
        {
            _importedTestItems.ForEach(x => { x.Category = ItemCategory.Medical; x.ImportProduct = false; });
            Models.PurchasedItem purchasedItem = ProcessReceipt();
            Assert.AreEqual(0m, purchasedItem.TaxPercentage);
        }

        [TestMethod]
        public void ItemCategoryTaxCalcForBookNotImported()
        {
            _importedTestItems.ForEach(x => { x.Category = ItemCategory.Book; x.ImportProduct = false; });
            Models.PurchasedItem purchasedItem = ProcessReceipt();
            Assert.AreEqual(0m, purchasedItem.TaxPercentage);
        }

        [TestMethod]
        public void ItemCategoryTaxCalcForFoodNotImported()
        {
            _importedTestItems.ForEach(x => { x.Category = ItemCategory.Food; x.ImportProduct = false; });
            Models.PurchasedItem purchasedItem = ProcessReceipt();
            Assert.AreEqual(0m, purchasedItem.TaxPercentage);
        }
        [TestMethod]
        public void CalculateTaxAmount()
        {
            _receiptHelper = new ReceiptHelper(new Models.PurchasedItemsViewModel() { PurchasedItems = _mockData.ImportedPurchasedItems });
            _receiptHelper.ProcessReceipt();
            var purchasedItem = _receiptHelper.ReceiptModel.PurchasedItems.FirstOrDefault();
            Assert.AreEqual(4.20m, purchasedItem.TaxAmount);
            Assert.AreEqual(32.19, purchasedItem.TotalUnitPrice);
        }
        private Models.PurchasedItem ProcessReceipt()
        {
            _receiptHelper = new ReceiptHelper(new Models.PurchasedItemsViewModel() { PurchasedItems = _importedTestItems });
            _receiptHelper.ProcessReceipt();
            var purchasedItem = _receiptHelper.ReceiptModel.PurchasedItems.FirstOrDefault();
            return purchasedItem;
        }
    }
}
