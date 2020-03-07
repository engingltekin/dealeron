using Dealeron.SalesTax.Extensions;
using Dealeron.SalesTax.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealeron.SalesTax.Tests.ExtensionTests
{
    [TestClass]
    public class EnumExtensionTests
    {
        [TestMethod]
        public void WelcomeSurveyExtensions()
        {
            // Given 
            foreach (Enum value in Enum.GetValues(typeof(ItemCategory)))
            {
                var displayName = value.GetDisplayName();
                Assert.IsNotNull(displayName);
            }

            // When 

            // Then 
        }
    }
}
