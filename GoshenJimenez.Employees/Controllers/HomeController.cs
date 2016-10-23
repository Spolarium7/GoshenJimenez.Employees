using GoshenJimenez.Employees.Models.Enums;
using GoshenJimenez.Employees.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoshenJimenez.Employees.Controllers
{
    [BasicAuth]
    public class HomeController : Controller
    {
        DAL.EmployeesBLL bll = new DAL.EmployeesBLL();


        [HttpGet, Route("index")]
        public ActionResult Index(int pageSize = 5, int pageIndex = 1, string sortBy = "LastName", bool isAscending = true, string keyword = "", string gender = "", string assignment = "", string status = "")
        {
            ViewModels.Employees.EmployeesPageViewModel model = new ViewModels.Employees.EmployeesPageViewModel()
            {
                Employees = bll.GetEmployees(pageSize, pageIndex, sortBy, isAscending, keyword, gender, assignment, status),
                AssignmentChoices = Enum.GetValues(typeof(Assignment)).Cast<Assignment>().ToList(),
                GenderChoices = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList(),
                StatusChoices = Enum.GetValues(typeof(EmployeeStatus)).Cast<EmployeeStatus>().ToList(),
                SortChoices = sortChoices(),
                Gender = gender,
                Status = status,
                Assignment = assignment
            };
            return View(model);
        }
        private List<string> sortChoices()
        {
            List<string> lst = new List<string>();
            lst.Add("FirstName");
            lst.Add("LastName");
            lst.Add("BaseSalary");
            return lst;
        }

        [HttpGet, Route("edit/{id}"), AuthorizeUser]
        public ActionResult Edit(string id)
        {
            ViewModels.Employees.EmployeeViewModel model = new ViewModels.Employees.EmployeeViewModel()
            {
                Employee = bll.GetEmployee(id),
                AssignmentChoices = Enum.GetValues(typeof(Assignment)).Cast<Assignment>().ToList(),
                GenderChoices = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList(),
                StatusChoices = Enum.GetValues(typeof(EmployeeStatus)).Cast<EmployeeStatus>().ToList(),
            };
            return View(model);
        }

        [HttpPost, Route("edit"), AuthorizeUser]
        public ActionResult Edit(ViewModels.Employees.EmployeeViewModel model)
        {
            model.AssignmentChoices = Enum.GetValues(typeof(Assignment)).Cast<Assignment>().ToList();
            model.GenderChoices = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            model.StatusChoices = Enum.GetValues(typeof(EmployeeStatus)).Cast<EmployeeStatus>().ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            };

            if (bll.Update(model.Employee) != null)
            {
                return RedirectToAction("index", new { keyword = model.Employee.LastName });
            }
            ModelState.AddModelError(string.Empty, "Something went wrong");
            return View(model);
        }


        [HttpGet, Route("create"), AuthorizeUser]
        public ActionResult Create()
        {
            ViewModels.Employees.EmployeeViewModel model = new ViewModels.Employees.EmployeeViewModel()
            {
                AssignmentChoices = Enum.GetValues(typeof(Assignment)).Cast<Assignment>().ToList(),
                GenderChoices = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList(),
                StatusChoices = Enum.GetValues(typeof(EmployeeStatus)).Cast<EmployeeStatus>().ToList(),
            };
            return View(model);
        }

        [HttpPost, Route("create"), AuthorizeUser]
        public ActionResult Create(ViewModels.Employees.EmployeeViewModel model)
        {
            model.AssignmentChoices = Enum.GetValues(typeof(Assignment)).Cast<Assignment>().ToList();
            model.GenderChoices = Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
            model.StatusChoices = Enum.GetValues(typeof(EmployeeStatus)).Cast<EmployeeStatus>().ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            };

            if (bll.Create(model.Employee) != null)
            {
                return RedirectToAction("index", new { keyword = model.Employee.LastName });
            }
            ModelState.AddModelError(string.Empty, "Something went wrong");
            return View(model);
        }

        [HttpPost, Route("remove")]
        public JsonResult Remove(Guid id)
        {
            var operation = bll.Delete(id);
            if (operation == true)
            {
                return Json("success", JsonRequestBehavior.AllowGet);
            }

            return Json("fail", JsonRequestBehavior.AllowGet);
        }

    }
}