using GoshenJimenez.Employees.Models;
using GoshenJimenez.Employees.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BCrypt.Net;

namespace GoshenJimenez.Employees.DAL
{
    public class UsersBLL
    {
        private EmployeesDbContext db = new EmployeesDbContext();

        public User Authenticate(string email, string password)
        {
            var user = db.Users.Where(a => a.Email.ToLower() == email.ToLower()).FirstOrDefault();

            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    user.NoOfLoginRetries = 0;
                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    user.NoOfLoginRetries = user.NoOfLoginRetries + 1;
                    if (user.NoOfLoginRetries >= 3 && (user.Status == UserStatus.Active || user.Status == UserStatus.Inactive))
                    {
                        user.Status = UserStatus.LockedOut;
                    }
                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    user = null;
                }
                return user;
            }
            return null;
        }

        public string Register(User user)
        {
            var duplicateUser = db.Users.Where(a => a.Email.ToLower() == user.Email.ToLower()).FirstOrDefault();
            if (duplicateUser == null)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return "Ok";
            }
            return "Duplicate email detected";
        }

        public User ChangePassword(Guid id, string oldPassword, string newPassword)
        {
            var user = db.Users.Where(a => a.Id == id).FirstOrDefault();

            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(oldPassword, user.Password))
                {
                    user.ClearTextPassword = newPassword;
                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    user = null;
                }
                return user;
            }
            return null;
        }
    }
}