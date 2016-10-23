using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GoshenJimenez.Employees.Models;
using GoshenJimenez.Employees.Models.Enums;

namespace GoshenJimenez.Employees.DAL
{
    public class DbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EmployeesDbContext>
    {
        protected override void Seed(EmployeesDbContext context)
        {
            context.Employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                Assignment = Assignment.Field,
                BaseSalary = 32000,
                FirstName = "Vraska",
                LastName = "Unseen",
                Gender = Gender.Female,
                Status = EmployeeStatus.Probationary
            });
            context.SaveChanges();
            context.Employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                Assignment = Assignment.Field,
                BaseSalary = 35000,
                FirstName = "Sarkhan",
                LastName = "Vol",
                Gender = Gender.Male,
                Status = EmployeeStatus.Probationary
            });
            context.SaveChanges();
            context.Employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                Assignment = Assignment.Field,
                BaseSalary = 37000,
                FirstName = "Nihiri",
                LastName = "Lithomancer",
                Gender = Gender.Female,
                Status = EmployeeStatus.Probationary
            });
            context.SaveChanges();
            context.Employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                Assignment = Assignment.Field,
                BaseSalary = 37000,
                FirstName = "Garruk",
                LastName = "Wildspeaker",
                Gender = Gender.Male,
                Status = EmployeeStatus.Probationary
            });
            context.SaveChanges();
            context.Employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                Assignment = Assignment.Field,
                BaseSalary = 41000,
                FirstName = "Kiora",
                LastName = "Tidegoddess",
                Gender = Gender.Female,
                Status = EmployeeStatus.Regular
            });
            context.SaveChanges();
            context.Employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                Assignment = Assignment.Field,
                BaseSalary = 44000,
                FirstName = "Nicol",
                LastName = "Bolas",
                Gender = Gender.Male,
                Status = EmployeeStatus.Regular
            });
            context.SaveChanges();
            context.Employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                Assignment = Assignment.Field,
                BaseSalary = 47000,
                FirstName = "Tamiyo",
                LastName = "Moonfolk",
                Gender = Gender.Female,
                Status = EmployeeStatus.Regular
            });
            context.SaveChanges();
            context.Employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                Assignment = Assignment.Office,
                BaseSalary = 50000,
                FirstName = "Sorin",
                LastName = "Markov",
                Gender = Gender.Male,
                Status = EmployeeStatus.Probationary
            });
            context.SaveChanges();
            context.Employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                Assignment = Assignment.Office,
                BaseSalary = 52000,
                FirstName = "Elspeth",
                LastName = "Tirel",
                Gender = Gender.Female,
                Status = EmployeeStatus.Probationary
            });
            context.SaveChanges();
            context.Employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                Assignment = Assignment.Office,
                BaseSalary = 55000,
                FirstName = "Gideon",
                LastName = "Gura",
                Gender = Gender.Male,
                Status = EmployeeStatus.Probationary
            });
            context.SaveChanges();
            context.Employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                Assignment = Assignment.Office,
                BaseSalary = 57000,
                FirstName = "Nissa",
                LastName = "Revane",
                Gender = Gender.Female,
                Status = EmployeeStatus.Probationary
            });
            context.SaveChanges();
            context.Employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                Assignment = Assignment.Office,
                BaseSalary = 59000,
                FirstName = "Jace",
                LastName = "Beleren",
                Gender = Gender.Male,
                Status = EmployeeStatus.Regular
            });
            context.SaveChanges();
            context.Employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                Assignment = Assignment.Office,
                BaseSalary = 61000,
                FirstName = "Chandra",
                LastName = "Nalaar",
                Gender = Gender.Female,
                Status = EmployeeStatus.Regular
            });
            context.SaveChanges();
            context.Employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                Assignment = Assignment.Office,
                BaseSalary = 64000,
                FirstName = "Liliana",
                LastName = "Vess",
                Gender = Gender.Female,
                Status = EmployeeStatus.Regular
            });
            context.SaveChanges();
            context.Employees.Add(new Employee()
            {
                Id = Guid.NewGuid(),
                Assignment = Assignment.Office,
                BaseSalary = 70000,
                FirstName = "Karn",
                LastName = "Silvergolem",
                Gender = Gender.Male,
                Status = EmployeeStatus.Regular
            });
            context.SaveChanges();
            context.Users.Add(new User()
            {
                Name = "Urza Planeswalker",
                Email = "urza@mailinator.com",
                ClearTextPassword = "@rc@n1s07"
            });
            context.SaveChanges();
        }
    }
}