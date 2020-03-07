using Dealeron.SalesTax.Helpers;
using Dealeron.SalesTax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dealeron.SalesTax.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            return View(new PurchasedItemsViewModel());
        }
        [HttpPost]
        public ActionResult New(PurchasedItemsViewModel model)
        {
            IReceiptHelper receipt = new ReceiptHelper(model);

            if (ModelState.IsValid)
            {
                if (receipt.ProcessReceipt())
                {
                    return View("Receipt", receipt.ReceiptModel);
                }
            }
            
            return View(model);
        }


        public ActionResult AddPurchasedItem()
        {
            var itemModel = new PurchasedItem();
            return PartialView("~/Views/Shared/EditorTemplates/AddPurchasedItem.cshtml", itemModel);
        }
    }
}