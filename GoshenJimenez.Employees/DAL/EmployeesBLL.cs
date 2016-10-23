using GoshenJimenez.Employees.Models;
using GoshenJimenez.Employees.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoshenJimenez.Employees.DAL
{
    public class EmployeesBLL
    {
        private EmployeesDbContext db = new EmployeesDbContext();
        public Paged<Employee> GetEmployees(int pageSize = 5, int pageIndex = 1, string sortBy = "LastName", bool isAscending = true, string keyword = "", string gender ="", string assignment = "", string status = "")
        {
            FixInt(ref pageSize, 5);
            FixInt(ref pageIndex, 1);

            var qry = db.Set<Employee>().AsQueryable<Employee>();

            #region Filtering
            if (!string.IsNullOrEmpty(keyword))
            {
                qry = qry.Where(r => r.FirstName.Contains(keyword)
                                   || r.LastName.Contains(keyword)
                                );
            };
            if (!string.IsNullOrEmpty(gender))
            {
                if(gender.ToLower() == Gender.Male.ToString().ToLower()) { 
                    qry = qry.Where(r => r.Gender == Gender.Male);
                }
                else if (gender.ToLower() == Gender.Female.ToString().ToLower())
                {
                    qry = qry.Where(r => r.Gender == Gender.Female);
                }
            };
            if (!string.IsNullOrEmpty(assignment))
            {
                if (assignment.ToLower() == Assignment.Field.ToString().ToLower())
                {
                    qry = qry.Where(r => r.Assignment == Assignment.Field);
                }
                else if (assignment.ToLower() == Assignment.Office.ToString().ToLower())
                {
                    qry = qry.Where(r => r.Assignment == Assignment.Office);
                }
            };
            if (!string.IsNullOrEmpty(status))
            {
                if (status.ToLower() == EmployeeStatus.Probationary.ToString().ToLower())
                {
                    qry = qry.Where(r => r.Status == EmployeeStatus.Probationary);
                }
                else if (status.ToLower() == EmployeeStatus.Regular.ToString().ToLower())
                {
                    qry = qry.Where(r => r.Status == EmployeeStatus.Regular);
                }
            };
            #endregion

            var qryCount = qry;
            var totalItems = qryCount.ToList().Count();

            #region Sorting
            if (isAscending == true)
            {
                if (!string.IsNullOrEmpty(sortBy))
                {
                   if(sortBy.ToLower() == "firstname")
                   {
                        qry = qry.OrderBy(a => a.FirstName);
                   }
                   else if (sortBy.ToLower() == "lastname")
                   {
                        qry = qry.OrderBy(a => a.LastName);
                   }
                   else if (sortBy.ToLower() == "basesalary")
                   {
                        qry = qry.OrderBy(a => a.BaseSalary);
                   };
                }
            }
            else {
                if (!string.IsNullOrEmpty(sortBy))
                {
                    if (sortBy.ToLower() == "firstname")
                    {
                        qry = qry.OrderByDescending(a => a.FirstName);
                    }
                    else if (sortBy.ToLower() == "lastname")
                    {
                        qry = qry.OrderByDescending(a => a.LastName);
                    }
                    else if (sortBy.ToLower() == "basesalary")
                    {
                        qry = qry.OrderByDescending(a => a.BaseSalary);
                    };
                }
            };
            #endregion

            var list = qry
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToList();

            return new Paged<Employee>()
            {
                Items = list,
                PageSize = pageSize,
                PageIndex = pageIndex,
                IsAscending = isAscending,
                SortBy = sortBy,
                Keyword = keyword,
                TotalItems = totalItems,
                TotalPages = Convert.ToInt32(Math.Ceiling(totalItems / (double)pageSize))
            };
        }
        private void FixInt(ref int number, int defaultValue)
        {
            if (number == null)
            {
                number = defaultValue;
            }

            if (number == 0)
            {
                number = defaultValue;
            }
        }

        public Employee GetEmployee(string id)
        {
            Guid Id = Guid.Parse(id);
            return db.Employees.FirstOrDefault(a => a.Id == Id);
        }

        public Employee Update(Employee employee)
        {
            Employee employeeRecord = db.Employees.FirstOrDefault(a => a.Id == employee.Id);
            if(employeeRecord != null)
            {
                employeeRecord.FirstName = employee.FirstName;
                employeeRecord.LastName = employee.LastName;
                employeeRecord.Assignment = employee.Assignment;
                employeeRecord.BaseSalary = employee.BaseSalary;
                employeeRecord.Gender = employee.Gender;
                employeeRecord.Status = employee.Status;
                db.SaveChanges();
            }
            return employee;
        }

        public Employee Create(Employee employee)
        {
            Employee employeeRecord = db.Employees.FirstOrDefault(a => a.Id == employee.Id);
            if (employeeRecord == null)
            {
                employeeRecord = new Employee();
                employeeRecord.FirstName = employee.FirstName;
                employeeRecord.LastName = employee.LastName;
                employeeRecord.Assignment = employee.Assignment;
                employeeRecord.BaseSalary = employee.BaseSalary;
                employeeRecord.Gender = employee.Gender;
                employeeRecord.Status = employee.Status;
                db.Employees.Add(employeeRecord);
                db.SaveChanges();
            }
            return employee;
        }

        public bool Delete(Guid id)
        {
            Employee employeeRecord = db.Employees.FirstOrDefault(a => a.Id == id);
            if (employeeRecord != null)
            {
                db.Employees.Remove(employeeRecord);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}