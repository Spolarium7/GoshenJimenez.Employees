using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoshenJimenez.Employees.ViewModels.Users
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is invalid"), EmailAddress(ErrorMessage = "Email is invalid")]
        public string Email { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Please input password.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}