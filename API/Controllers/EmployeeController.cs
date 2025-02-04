using Microsoft.AspNetCore.Mvc;
using Employee.Application.Employees.Models;
using Employee.Application.Employees.Services;
using Employee.Domain.SeedWork;

namespace Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService, INotification notification) : base(notification)
        {
            _employeeService = employeeService;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Response(await _employeeService.GetAsync());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Response(await _employeeService.GetAsync(id));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeRequest employeeRequest)
        {
            if (!ModelState.IsValid)
            {
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        AddNotification(error.ErrorMessage);
                    }
                }
                return Response();
            }

            return Response(await _employeeService.AddAsync(employeeRequest));
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeRequest employeeRequest)
        {
            // Implementation for updating employee
            // Not required as per user story, but placeholder provided
            return Ok();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Implementation for deleting employee
            // Not required as per user story, but placeholder provided
            return Ok();
        }
    }
}