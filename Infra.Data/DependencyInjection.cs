using Employee.Infra.Data.Employees.Repository;
using Employee.Application.Employees.Services;
using Employee.Application.Employees.Services;

namespace Employee.Infra.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            // Add other repositories here

            return services;
        }
    }
}