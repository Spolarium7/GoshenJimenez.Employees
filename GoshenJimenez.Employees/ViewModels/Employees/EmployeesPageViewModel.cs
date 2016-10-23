using GoshenJimenez.Employees.DAL;
using GoshenJimenez.Employees.Models;
using GoshenJimenez.Employees.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoshenJimenez.Employees.ViewModels.Employees
{
    public class EmployeesPageViewModel
    {
        public Paged<Employee> Employees { get; set; }
        public List<Assignment> AssignmentChoices { get; set; }
        public List<EmployeeStatus> StatusChoices { get; set; }
        public List<Gender> GenderChoices { get; set; }
        public List<string> SortChoices { get; set; }
        public string Gender { get; set; }
        public string Assignment { get; set; }
        public string Status { get; set; }

    }
}