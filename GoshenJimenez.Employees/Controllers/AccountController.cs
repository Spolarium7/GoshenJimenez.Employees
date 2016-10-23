using GoshenJimenez.Employees.Models;
using GoshenJimenez.Employees.Security;
using GoshenJimenez.Employees.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoshenJimenez.Employees.Controllers
{
    public class AccountController : Controller
    {
        DAL.UsersBLL bll = new DAL.UsersBLL();
        // GET: Account
        #region Login
        [HttpGet, AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public ActionResult Login(LoginViewModel request)
        {
            var response = bll.Authenticate(request.Email, request.Password);

            if (response != null)
            {
                WebUser.CurrentUser = response;
                return RedirectToAction("index", "home");
            }
            else
            {
                this.ModelState.AddModelError(string.Empty, "Email or password not recognized");
                return View();
            }

            return View();
        }
        #endregion

        #region Logoff
        public ActionResult Logoff()
        {
            //AuthenticationManager.SignOut();

            Session.Abandon();
            Session.RemoveAll();
            Session.Clear();

            /* clear session cookie */
            HttpCookie cookie = new HttpCookie("ASP.NET_SessionId", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            HttpRuntime.Close();

            return RedirectToAction("index", "home");
        }
        #endregion

        #region Profile
        [HttpGet, AuthorizeUser]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel request)
        {
            if (request.Password != request.ConfirmPassword)
            {
                return View(request);
            }

            if (!ModelState.IsValid)
            {
                return View(request);
            };

            var response = bll.ChangePassword(WebUser.CurrentUser.Id, request.OldPassword, request.Password);

            if (response != null)
            {
                WebUser.CurrentUser = response;
                return RedirectToAction("index", "home");
            }
            else
            {
                this.ModelState.AddModelError(string.Empty, "Something went wrong.");
                return View();
            }

            return View();
        }
        #endregion

        #region Registration
        [HttpGet, AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public ActionResult Register(RegisterViewModel request)
        {
            User user = new Models.User();
            user.ClearTextPassword = request.Password;
            user.Name = request.Name;
            user.Email = request.Email.ToLower();

            var response = bll.Register(user);

            if (response.ToLower() == "ok")
            {
                return RedirectToAction("login", "account");
            }
            else
            {
                this.ModelState.AddModelError(string.Empty, response);
                return View();
            }

            return View();
        }
        #endregion

    }
}