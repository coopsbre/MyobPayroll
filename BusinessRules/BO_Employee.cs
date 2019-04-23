namespace MyobPayroll.BusinessRules
{
    public class BO_Employee
    {
        private string firstname;
        private string surname;
        private decimal annualsalary; 

        public BO_Employee(string firstname, string surname, decimal annualsalary)
        {
            this.firstname = firstname;
            this.surname = surname;
            this.annualsalary = annualsalary;
        }

        public Employee GetEmployee(bool createauto=false)
        {
            Employee employee;

            DataLayer.DL_Employee dl_Employee = new DataLayer.DL_Employee();

            employee = dl_Employee.Get(firstname, surname);

            if (employee == null && createauto)
            {
                CreateEmployee();
            }

            return employee;
        }

        public Employee CreateEmployee()
        {
            DataLayer.DL_Employee dl_Employee = new DataLayer.DL_Employee();

            return dl_Employee.Create(firstname, surname, annualsalary);
        }
    }
}
