using System;

namespace MyobPayroll.BusinessRules
{
    public class BO_PaySlip
    {
       
        /// <summary>
        /// Purpose:- Create a payslip for an employee for a particular date.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool CreatePaySlip(MonthYear monthYear, Employee employee, BO_IncomeTax bo_IncomeTax)
        {
            DataLayer.DL_Payslip dL_Payslip = new DataLayer.DL_Payslip();

            var incomeTax = bo_IncomeTax.CalcuateIncomeTax(monthYear.CalendarYear.YearName, employee.AnnualSalary);
            var grossIncome = decimal.Round(employee.AnnualSalary / 12, MidpointRounding.AwayFromZero);
            
            // Create a new payslip.
            return dL_Payslip.Create(new PaySlip()
            {
                EmployeeID = employee.EmployeeID,
                MonthYearID = monthYear.MonthYearID,
                GrossIncome = grossIncome,
                IncomeTax = incomeTax,
                NetIncome = grossIncome - incomeTax,
                SuperAmount = decimal.Round((grossIncome) * employee.SuperPercent,MidpointRounding.AwayFromZero),
                GeneratedOn = DateTime.Now.ToLocalTime()
            });
        }

        /// <summary>
        /// Method in charge of generating a payslip.
        /// </summary>
        /// <param name="firstname">FirstName of the Employee</param>
        /// <param name="surname">Surname of the Employee</param>
        /// <param name="annualsalary">Annual Salary of the Employee</param>
        /// <param name="super">Superannuation Percentage of the Employee</param>
        /// <param name="payStartDate">Payment StartDate</param>
        /// <returns></returns>
        public BO_PaySlip GeneratePay(string firstname, string surname, decimal annualsalary, decimal super, DateTime payStartDate)
        {
            if (IsValidPayParameters(annualsalary,super))
            {
                // 1) Get the employee Id from the database.
                BO_Employee bo_Employee = new BO_Employee(firstname, surname, annualsalary);
                Employee employee = bo_Employee.GetEmployee(createauto: true);

                // Super and annual salary may have changed in this case update.

                // 2) Get the month year id from the database.
                BO_MonthYear bo_monthYear = new BO_MonthYear();
                MonthYear monthYear = bo_monthYear.GetMonthYear(payStartDate);

                if (!HasBeenPaid(employee, monthYear))
                {
                    // 3) Create the Payslip.
                    this.CreatePaySlip(monthYear, employee, new BO_IncomeTax());
                }
            }
            return this;
        } 
        

        private bool IsValidPayParameters(decimal annualSalary, decimal super)
        {
            return (annualSalary > 0) && (super >= 0 && super <= 50);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool HasBeenPaid(Employee employee, MonthYear monthYear)
        {
            DataLayer.DL_Payslip dL_Payslip = new DataLayer.DL_Payslip();
            PaySlip payslip = dL_Payslip.GetPayslip(employee.EmployeeID, monthYear.MonthYearID);

            return payslip != null;
        }
    }
}
