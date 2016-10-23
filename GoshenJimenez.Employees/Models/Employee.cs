using GoshenJimenez.Employees.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoshenJimenez.Employees.Models
{
    public class Employee
    {
       public Guid Id { get; set; }

       [Required(ErrorMessage = "Please indicate employee firstname.")]
       public string FirstName { get; set; }
       [Required(ErrorMessage = "Please indicate employee lastname.")]
       public string LastName { get; set; }
       [Required(ErrorMessage = "Please select a gender for this employee")]
       public Gender Gender { get; set; }
        [Required(ErrorMessage = "Please select a status for this employee")]
        public EmployeeStatus Status { get; set; }
        [Required(ErrorMessage = "Please select an assignment for this employee")]
        public Assignment Assignment { get; set; }
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Please provide proper salary format")]
        public double BaseSalary{ get; set; }

        public Employee()
        {
            this.Id = Guid.NewGuid();
        }
    }
}