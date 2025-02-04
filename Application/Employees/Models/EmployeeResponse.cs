using Employee.Application.Common;
using Employee.Domain.Employees;

namespace Employee.Application.Employees.Models
{
    public class EmployeeResponse : BaseResponse
    {
        public int EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
        public string? EmployeeAddress { get; set; }

        public static implicit operator EmployeeResponse(Employee employee)
        {
            if (employee == null) return new EmployeeResponse();
            return new EmployeeResponse
            {
                EmployeeID = employee.EmployeeID,
                EmployeeName = employee.EmployeeName,
                EmployeeAge = employee.EmployeeAge,
                EmployeeAddress = employee.EmployeeAddress
            };
        }
    }
}