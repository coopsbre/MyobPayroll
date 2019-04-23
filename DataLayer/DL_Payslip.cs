using System;
using System.Collections.Generic;
using System.Linq;

namespace MyobPayroll.DataLayer
{
    public class DL_Payslip
    {
        public bool Create(PaySlip payslip)
        {
            MyobPayrollEntitiesTwo container = new MyobPayrollEntitiesTwo();
             
            container.PaySlips.Add(payslip);
            
            return container.SaveChanges() > 0;
        }

        internal PaySlip GetPayslip(int employeeID, int monthYearID)
        {
            MyobPayrollEntitiesTwo container = new MyobPayrollEntitiesTwo();

            var paySlips = container.PaySlips.Where(x => x.EmployeeID == employeeID &&
                                        x.MonthYearID == monthYearID).ToList();

            return paySlips.FirstOrDefault();
        }

        internal List<PaySlip> GetListOfPayslips(List<int> payslipIds)
        {
            MyobPayrollEntitiesTwo container = new MyobPayrollEntitiesTwo();

            var paySlips = container.PaySlips.Where(x => payslipIds.Contains(x.PaySlipID)).ToList();

            return paySlips;
        }
    }
}
