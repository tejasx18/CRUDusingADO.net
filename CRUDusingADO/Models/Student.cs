using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace CRUDusingADO.Models
{
    public class Student
    {
        [Key]
        [Display(Name = "Student RollNo")]
        public int RollNo { get; set; }

        [Required]
        [Display(Name = "Student Name")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Student Branch")]
        public string? Branch { get; set; }

        [Required]
        [Display(Name = "Student Percentage")]
        [Range(minimum: 0, maximum: 100)]
        public double Percentage { get; set; }
    }
}
