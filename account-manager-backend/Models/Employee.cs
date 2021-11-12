using System.ComponentModel.DataAnnotations;

namespace account_manager_backend.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public int AccountId { get; set; }
        public string? Name { get; set; }
    }
}
