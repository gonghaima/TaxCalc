using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxCalc.Models
{
    public class RateFactory : IRateFactory
    {
        decimal _income;
        decimal _rate;

        public static readonly decimal[] rates = new[] { 0.115m, 0.210m, 0.315m, 0.355m };


        public RateFactory(decimal incomeAmount)
        {
            _income = incomeAmount;
        }
        public decimal getTaxRate()
        {
            if (_income <= 14000m)
            {
                _rate = rates[0];
            }
            else if (_income <= 48000m)
            {
                _rate = rates[1];
            }
            else if (_income <= 70000m)
            {
                _rate = rates[2];
            }
            else
            {
                _rate = rates[3];
            }

            return _rate;
        }

        public decimal totalTax()
        {
            decimal totalTax = 0m;

            List<decimal> fourCategory = TaxableList(_income);

            for (int i = 0; i < fourCategory.Count();i++ )
            {
                totalTax += fourCategory[i] * rates[i];
            }
            return totalTax;
        }

        public List<decimal> TaxableList(decimal paramIncome)
        {
            decimal above70k = (paramIncome - 70000m) > 0 ? (paramIncome - 70000m) : 0;
            decimal between48_70k = (paramIncome - 48000m) > 0 ? ((paramIncome - 48000m) - (((_income - 70000m) > 0) ? (paramIncome - 70000m) : 0)) : 0;
            decimal between14_48k = (paramIncome - 14000m) > 0 ? ((paramIncome - 14000m) - (((paramIncome - 48000m) > 0) ? (paramIncome - 48000m) : 0)) : 0;
            decimal between0_14k = (paramIncome - 0m) > 0 ? ((paramIncome - 0m) - (((paramIncome - 14000m) > 0) ? (paramIncome - 14000m) : 0)) : 0;

            List<decimal> fourCategory = new List<decimal>();
            fourCategory.Add(between0_14k);
            fourCategory.Add(between14_48k);
            fourCategory.Add(between48_70k);
            fourCategory.Add(above70k);

            return fourCategory;
        }
    }

}