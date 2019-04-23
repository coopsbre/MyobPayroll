using System.Collections.Generic;
using System.Linq;

namespace MyobPayroll.DataLayer
{
    public class DL_IncomeTaxRates
    {
        public List<IncomeTaxRate> Get(int year, decimal income)
        {
            MyobPayrollEntitiesTwo container = new MyobPayrollEntitiesTwo();

            var incomeTaxRates = container.IncomeTaxRates.Where(x => x.IncomeYear == year &&
                                                 income >= x.LowBand &&
                                                 income <= x.HighBand).ToList();

            return incomeTaxRates;
        }
    }
}
