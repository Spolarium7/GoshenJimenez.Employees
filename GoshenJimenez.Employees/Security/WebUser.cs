using GoshenJimenez.Employees.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoshenJimenez.Employees.Security
{
    public static class WebUser
    {
        public static User CurrentUser
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session["CurrentUser"] != null)
                {
                    return (User)HttpContext.Current.Session["CurrentUser"];
                }

                return null;
            }
            set { HttpContext.Current.Session["CurrentUser"] = value; }
        }


    }
}