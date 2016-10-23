using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoshenJimenez.Employees.ViewModels.Users
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email or password is invalid"), EmailAddress(ErrorMessage ="Email or password is invalid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Email or password is invalid")]
        public string Password { get; set; }
    }
}