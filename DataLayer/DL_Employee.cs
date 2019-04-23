using System.Linq;

namespace MyobPayroll.DataLayer
{
    public class DL_Employee
    {
        public Employee Get(string firstname, string surname)
        {
            MyobPayrollEntitiesTwo container = new MyobPayrollEntitiesTwo();

            var employeeList = container.Employees.Where(x => x.Firstname.Trim().ToUpper() == firstname.Trim().ToUpper() &&
                                                          x.Surname.Trim().ToUpper() == surname.Trim().ToUpper()).ToList();

            return employeeList.FirstOrDefault();
        }

        internal Employee Create(string firstname, string surname, decimal annualSalary, decimal superperc)
        {
            MyobPayrollEntitiesTwo container = new MyobPayrollEntitiesTwo();
            Employee employee = new Employee()
            {
                Firstname = firstname,
                Surname = surname,
                AnnualSalary = annualSalary,
                SuperPercent = superperc
            };

            container.Employees.Add(employee);

            container.SaveChanges();

            return employee;
        }
    }
}
