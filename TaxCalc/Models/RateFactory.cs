using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxCalc.Models
{
    public class RateFactory
    {
        decimal _income;
        decimal _rate;
        public RateFactory(decimal incomeAmount)
        {
            _income = incomeAmount;
        }
        public decimal getTaxRate()
        {
            if (_income <= 14000m)
            {
                _rate = 0.115m;
            }
            else if (_income <= 48000m)
            {
                _rate = 0.21m;
            }
            else if (_income <= 70000m)
            {
                _rate = 0.315m;
            }
            else
            {
                _rate = 0.355m;
            }

            return _rate;
        }
    }

}