using System;

namespace MyobPayroll.BusinessRules
{
    public class BO_MonthYear
    {
        public MonthYear GetMonthYear(DateTime payStartDate)
        {
            MonthYear monthYear;

            DataLayer.DL_MonthYear dL_MonthYear = new DataLayer.DL_MonthYear();

            monthYear = dL_MonthYear.Get(payStartDate);

            return monthYear;
        }
    }
}
