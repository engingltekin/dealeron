using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dealeron.SalesTax;
using Dealeron.SalesTax.Controllers;

namespace Dealeron.SalesTax.Tests.Controllers
{
    [TestClass]
    public class PurchaseControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            PurchaseController controller = new PurchaseController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void New()
        {
            // Arrange
            PurchaseController controller = new PurchaseController();

            // Act
            ViewResult result = controller.New() as ViewResult;

            // Assert
        }

        
    }
}
