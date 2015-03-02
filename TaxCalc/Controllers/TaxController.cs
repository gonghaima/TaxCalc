using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaxCalc.Models;

namespace TaxCalc.Controllers
{
    public class TaxController : Controller
    {
        //
        // GET: /Tax/
        public ActionResult GetTaxValue(decimal incomeAmount)
        {
            RateFactory rateFactory = new RateFactory(incomeAmount);
            return Json(incomeAmount*rateFactory.getTaxRate());
        }
	}
}