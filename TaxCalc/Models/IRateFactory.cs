using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxCalc.Models
{
    public interface IRateFactory
    {
        decimal getTaxRate();
        decimal totalTax();
    }
}