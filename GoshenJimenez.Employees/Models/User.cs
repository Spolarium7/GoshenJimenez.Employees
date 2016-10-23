using GoshenJimenez.Employees.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoshenJimenez.Employees.Models
{
    public class User
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Please indicate name for this user.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please indicate user email."), EmailAddress(ErrorMessage = "Please valid user email.")]
        public string Email { get; set; }
        public string Password { get; set; }
        public string ClearTextPassword
        {
            set { Password = !string.IsNullOrEmpty(value) ? BCrypt.Net.BCrypt.HashPassword(value) : null; }
        }
        public int NoOfLoginRetries { get; set; }
        public string VerificationCode { get; set; }
        public Boolean PasswordIsGenerated { get; set; }
        public UserStatus Status { get; set; }
        public User()
        {
            this.Id = Guid.NewGuid();
            this.VerificationCode = System.Web.Security.Membership.GeneratePassword(6, 0);
            this.NoOfLoginRetries = 0;
            this.PasswordIsGenerated = false;
            this.Status = UserStatus.Active;
        }
    }
}