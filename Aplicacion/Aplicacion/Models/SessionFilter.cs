using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplicacion.Models
{
    public class SessionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Session["User_Role"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(

                    new System.Web.Routing.RouteValueDictionary
                    {
                        {"controller", "LogIn"},
                        {"action", "UserLogIn"}
                    }
                    );
                base.OnActionExecuted(filterContext);
            }
        }
    }
}