using GoshenJimenez.Employees.Models;
using GoshenJimenez.Employees.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoshenJimenez.Employees.ViewModels.Employees
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public List<Assignment> AssignmentChoices { get; set; }
        public List<EmployeeStatus> StatusChoices { get; set; }
        public List<Gender> GenderChoices { get; set; }

    }
}