using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace Dealeron.SalesTax.Extensions
{
    public static  class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            var displayName = value.GetType().GetMember(value.ToString()).First().GetCustomAttribute<DisplayAttribute>();
            return ReferenceEquals(displayName, null) ? value.ToString() : displayName.GetName();
        }
    }
}