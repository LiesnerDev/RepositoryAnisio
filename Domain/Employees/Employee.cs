using Employee.Domain.SeedWork;

namespace Employee.Domain.Employees
{
    public class Employee : Entity<int>
    {
        protected Employee() { }

        public Employee(int employeeID, string name, int age, string address)
        {
            EmployeeID = employeeID;
            EmployeeName = name;
            EmployeeAge = age;
            EmployeeAddress = address;
        }

        public int EmployeeID { get; private set; }
        public string? EmployeeName { get; private set; }
        public int EmployeeAge { get; private set; }
        public string? EmployeeAddress { get; private set; }

        public static Employee Create(int employeeID, string name, int age, string address)
        {
            // Additional domain logic can be added here
            return new Employee(employeeID, name, age, address);
        }
    }
}