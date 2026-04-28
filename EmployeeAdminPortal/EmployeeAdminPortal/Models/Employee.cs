using System.ComponentModel.DataAnnotations;

namespace EmployeeAdminPortal.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public required decimal Salary { get; set; }
        public required string Phone { get; set; }
        public string? Email { get; set; } = null;
    }
}
