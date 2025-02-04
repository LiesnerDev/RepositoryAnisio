using System.ComponentModel.DataAnnotations;

namespace Employee.Application.Employees.Models
{
    public class EmployeeRequest
    {
        [Required]
        [Range(1000, 9999, ErrorMessage = "EmployeeID must be a 4-digit number.")]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "EmployeeName cannot exceed 20 characters.")]
        public string? EmployeeName { get; set; }

        [Required]
        [Range(0, 99, ErrorMessage = "EmployeeAge must be a 2-digit number.")]
        public int EmployeeAge { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "EmployeeAddress cannot exceed 30 characters.")]
        public string? EmployeeAddress { get; set; }
    }
}