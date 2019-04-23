using System;
using System.Linq;

namespace MyobPayroll.BusinessRules
{
    public class BO_IncomeTax
    {
        /// <summary>
        /// Purpose is to calculate the income tax given 
        /// the income year and the acutal income.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="income"></param>
        public decimal CalcuateIncomeTax(int year, decimal income)
        {
            decimal incomeTaxAmount = 0.00m; 

            // Using the income and year get the income tax rate.
            DataLayer.DL_IncomeTaxRates dL_IncomeTaxRates = new DataLayer.DL_IncomeTaxRates();

            var incomeTaxRates = dL_IncomeTaxRates.Get(year, income);

            if (incomeTaxRates.Any())
            {
                // Get the first income tax record.
                var incomeTax = incomeTaxRates.First();

                //Get the income tax rule if applicable.
                var incomeTaxRule = incomeTax.IncomeTaxRule;

                if (incomeTaxRule != null)
                {
                    incomeTaxAmount = (incomeTaxRule.StartAmount + (income - incomeTaxRule.OverIncomeAmount) * incomeTaxRule.SeedAmount) / 12;

                    incomeTaxAmount = decimal.Round((decimal)incomeTaxAmount, MidpointRounding.AwayFromZero);
                }
            }

            return incomeTaxAmount;
        }
    }
}
