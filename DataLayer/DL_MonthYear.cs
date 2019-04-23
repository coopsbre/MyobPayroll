using System;
using System.Linq;

namespace MyobPayroll.DataLayer
{
    public class DL_MonthYear
    {
        public MonthYear Get(DateTime payStartDate)
        {
            MyobPayrollEntitiesTwo container = new MyobPayrollEntitiesTwo();

            string payMonth = payStartDate.ToString("MMMM");

            var monthYears = container.MonthYears.Where(x => x.CalendarYear.YearName == payStartDate.Year
                                          && x.CalendarMonth.MonthName == payMonth).ToList();

            return monthYears.FirstOrDefault();
        }
    }
}
