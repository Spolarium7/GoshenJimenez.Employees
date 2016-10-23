using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GoshenJimenez.Employees.DAL
{
    public class EmployeesDbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public EmployeesDbContext() : base("name=EmployeesDbContext")
        {
            Database.SetInitializer<EmployeesDbContext>(new CreateDatabaseIfNotExists<EmployeesDbContext>());
        }

        public System.Data.Entity.DbSet<GoshenJimenez.Employees.Models.Employee> Employees { get; set; }
        public System.Data.Entity.DbSet<GoshenJimenez.Employees.Models.User> Users { get; set; }
    }
}