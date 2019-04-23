using MyobPayroll.BusinessRules;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyobPayroll
{
    class Program
    {
        static void Main(string[] args)
        {
            var paySlips = GetPayslipsToProcess();
            if (paySlips.Any())
            {
                var paySlipsProcessed = ProcessPayslips(paySlips);
                if (paySlipsProcessed.Any())
                {
                    ExportPayslipsToCSV(GetListOfPaySlips(paySlipsProcessed));
                }
            }
        }

        private static List<int> ProcessPayslips(List<string> payslips)
        {
            BO_PaySlip bo_PaySlip = new BO_PaySlip();
            List<int> payslipIds = new List<int>();

            string firstname = string.Empty;
            string surname = string.Empty;
            string yearString = string.Empty;
            string monthString = string.Empty; 

            int year = 0;
            int month = 0;
            decimal salary = 0M;
            decimal super = 0M;
            string stringMonthYear = string.Empty;
            DateTime payDate;
            

            foreach (var payslip in payslips)
            {
                var splitArray = payslip.Split(',');

                //First Position is firstName 
                firstname = splitArray[0];
                surname = splitArray[1];
                salary = Decimal.Parse(splitArray[2]);
                super = Decimal.Parse(splitArray[3]);
                stringMonthYear = splitArray[4];
                yearString = stringMonthYear.Substring(stringMonthYear.Length - 4);
                year = Convert.ToInt16(yearString);
                monthString = stringMonthYear.Replace(" " + yearString, "");

                month = DateTime.ParseExact(monthString, "MMMM", CultureInfo.CurrentCulture).Month;
                payDate = new DateTime(year, month, 01);

                if (bo_PaySlip.GeneratePay(firstname, surname, salary, super, payDate))
                {
                    payslipIds.Add(bo_PaySlip.PaySlipID);
                }
            }

            return payslipIds;
        }

        private static List<PaySlip> GetListOfPaySlips(List<int> payslipIds)
        {
            BO_PaySlip bo_PaySlip = new BO_PaySlip();
            return bo_PaySlip.GetLitOfPaySlips(payslipIds);

        }

        private static void OuputPayslipsProcessed()
        {

        }

        private static void ExportPayslipsToCSV(List<PaySlip> paysliplist)
        {
            string csvFile = @"C:\brendon\Myob\MyobPayroll\Output.csv";

            if (File.Exists(csvFile))
            {
                string payslipline = string.Empty;
                List<string> fileContents = new List<string>(); 

                foreach (var payslip in paysliplist)
                {
                    payslipline = payslip.Employee.Firstname + " " + payslip.Employee.Surname + ',' +
                                  payslip.MonthYear.CalendarMonth.MonthName + " " + payslip.MonthYear.CalendarYear.YearName + ',' +
                                  payslip.GrossIncome.ToString() + "," +
                                  payslip.IncomeTax.ToString() + "," +
                                  payslip.NetIncome.ToString() + "," +
                                  payslip.SuperAmount.ToString();

                    fileContents.Add(payslipline);
                }

                File.WriteAllLines(csvFile, fileContents.ToArray());
            }
        }

        private static List<string> GetPayslipsToProcess()
        {
            string csvFile = @"C:\brendon\Myob\MyobPayroll\Input.csv";
            List<string> fileLines = new List<string>();

            if (File.Exists(csvFile))
            {
                fileLines = File.ReadAllLines(csvFile).ToList();

                foreach (var line in fileLines)
                {
                    Console.WriteLine(line);
                }
            }

            return fileLines;
        }
    }
}
