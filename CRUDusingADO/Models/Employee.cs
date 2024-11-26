using System.ComponentModel.DataAnnotations;

namespace CRUDusingADO.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }

        [Required]
        [Display(Name = "Employee Name")]
        public string? Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Id")]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Employee Salary")]
        public double Salary { get; set; }
    }
}
