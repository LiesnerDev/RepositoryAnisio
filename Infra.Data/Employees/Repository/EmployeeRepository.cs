using Employee.Domain.Employees;
using Employee.Domain;
using Microsoft.EntityFrameworkCore;

namespace Employee.Infra.Data.Employees.Repository
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }

        // Additional repository methods specific to Employee can be added here
    }
}