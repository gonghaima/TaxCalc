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
        IRateFactory _rateFactory;
        public TaxController(IRateFactory rateFactory)
        {
            _rateFactory = rateFactory;
        }
        //
        // GET: /Tax/
        public ActionResult GetTaxValue()
        {
            return Json(_rateFactory.totalTax());
        }
	}
}