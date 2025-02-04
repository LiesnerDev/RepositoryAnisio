using Employee.Domain.Employees;
using Employee.Domain;

namespace Employee.Infra.Data.Employees.Repository
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
    }
}