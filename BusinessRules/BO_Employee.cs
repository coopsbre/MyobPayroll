using System;

namespace MyobPayroll.BusinessRules
{
    public class BO_Employee
    {
        private string firstname;
        private string surname;
        private decimal annualsalary;
        private decimal superperc;

        public BO_Employee(string firstname, string surname, decimal annualsalary, decimal superperc )
        {
            this.firstname = firstname;
            this.surname = surname;
            this.annualsalary = annualsalary;
            this.superperc = superperc / 100;
        }

        public BO_Employee()
        {
        }

        public Employee GetEmployee(bool createauto=false)
        {
            Employee employee = null;

            try
            {
                DataLayer.DL_Employee dl_Employee = new DataLayer.DL_Employee();

                Console.Write("About to get employee");
                employee = dl_Employee.Get(firstname, surname);

                if (employee == null && createauto)
                {
                    employee = CreateEmployee();
                }
                else
                {
                    Console.Write("About to write employee firstname");
                    Console.Write(employee.Firstname);
                }

            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return employee;
        }

        public Employee CreateEmployee()
        {
            DataLayer.DL_Employee dl_Employee = new DataLayer.DL_Employee();

            return dl_Employee.Create(firstname, surname, annualsalary, superperc);
        }

        internal void Delete()
        {
            
        }
    }
}
