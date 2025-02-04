using Employee.Application.Employees.Models;

namespace Employee.Application.Employees.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeResponse> AddAsync(EmployeeRequest employeeRequest);
        Task<EmployeeResponse> GetAsync(int id);
        Task<IEnumerable<EmployeeResponse>> GetAsync();
    }
}