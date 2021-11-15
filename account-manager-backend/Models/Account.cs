using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace account_manager_backend.Models
{
    public class Account
    {   
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? ContactName { get; set; }
        public string? ContactPhone { get; set; }
        public string? Address  { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int? PostalCode { get; set; }
        [Required]
        public bool IsObsolete { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

        public IList<Employee>? Employees { get; set; }
    }
}
