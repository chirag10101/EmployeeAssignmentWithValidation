
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAssignmentWithValidation.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Please enter Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        [MinLength(3, ErrorMessage = "Min 3 alphabets needed")]
        [StringLength(30, ErrorMessage = "Max 30 chracters are allowed")]
        [RegularExpression("[a-zA-Z ]+", ErrorMessage = "Only alphabets allowed")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Date of Joining")]
        [Remote("Checkdate", "employee", ErrorMessage = "Doj should be less than current date ")]
        public DateTime DateOfJoining { get; set; }
        [Required(ErrorMessage = "Please enter Salary")]
        public double Salary { get; set; }
        [Required(ErrorMessage = "Please enter Department")]
        [MinLength(2, ErrorMessage = "Min 2 Characters needed")]
        public string Department { get; set; }
    }

}
