using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace account_manager_backend.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [Required]
        public int AccountId { get; set; }
        [Required]
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? PostalCode { get; set; }
        [Required]
        public bool IsObsolete { get; set; }
        public DateTime HireDate { get; set; }
    }
}
