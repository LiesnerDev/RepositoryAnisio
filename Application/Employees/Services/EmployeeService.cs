using Employee.Application.Common;
using Employee.Application.Employees.Models;
using Employee.Domain.SeedWork;
using Employee.Domain.Employees;
using Employee.Infra.Data.Employees.Repository;

namespace Employee.Application.Employees.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(INotification notification, IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
            : base(notification)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<EmployeeResponse> AddAsync(EmployeeRequest employeeRequest) => await ExecuteAsync(async () =>
        {
            var existingEmployee = await _employeeRepository.GetByIDAsync(employeeRequest.EmployeeID);
            if (existingEmployee != null)
            {
                AddNotification("EmployeeID", "An employee with this ID already exists.");
                return null;
            }

            var employee = Employee.Create(employeeRequest.EmployeeID, employeeRequest.EmployeeName, employeeRequest.EmployeeAge, employeeRequest.EmployeeAddress);

            await _employeeRepository.InsertAsync(employee);
            await _unitOfWork.SaveChangesAsync();

            return employee;
        }, exceptionMessage: "An error occurred while adding the employee.");

        public async Task<EmployeeResponse> GetAsync(int id) => await ExecuteAsync(async () =>
        {
            var employee = await _employeeRepository.GetByIDAsync(id);
            if (employee == null)
            {
                AddNotification("Employee", "Employee not found.");
                return null;
            }
            return employee;
        }, exceptionMessage: "An error occurred while retrieving the employee.");

        public async Task<IEnumerable<EmployeeResponse>> GetAsync() => await ExecuteAsync(async () =>
        {
            var employees = _employeeRepository.GetAll().ToList();
            return employees;
        }, exceptionMessage: "An error occurred while retrieving employees.");
    }
}