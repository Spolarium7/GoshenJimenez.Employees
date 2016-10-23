using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace GoshenJimenez.Employees.Security
{
    public class BasicAuth : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            var user = WebUser.CurrentUser;
            if (user == null)
            {
                filterContext.Result = new RedirectResult("~\\account\\login");
            }
        }
    }
}