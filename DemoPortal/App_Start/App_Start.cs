using DemoPortal.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace DemoPortal.App_Start
{
    public class App_Start
    {
        public class SessionExpire : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                HttpContext ctx = HttpContext.Current;
                if (HttpContext.Current.Session["UserDetail"] == null)
                {

                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        filterContext.HttpContext.Response.StatusCode = 401;
                        filterContext.Result = new JsonResult
                        {
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                            Data = new { Url = "/Login/Login" }
                        };
                    }
                    else
                    {
                        filterContext.Result = new RedirectResult("~/Login/Login");
                    }
                    return;
                }
                base.OnActionExecuting(filterContext);
            }
        }

        public class UserAuthorize : AuthorizeAttribute
        {

            private readonly string[] allowedroles;
            public UserAuthorize(params string[] roles)
            {
                this.allowedroles = roles;
            }
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
                UserSetting context = new UserSetting(); // my entity  

                bool authorize = false;
                foreach (var role in allowedroles)
                {
                    if (context.UserLoginType.ToString().ToLower() == role.ToString().ToLower())
                    {
                        authorize = true;
                    }
                }
                return authorize;
            }

            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                //filterContext.Result = new HttpUnauthorizedResult();
                //filterContext.HttpContext.Response.Redirect("~/Error/Unauthorized", false);
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.HttpContext.Response.StatusCode = 401;
                    filterContext.Result = new JsonResult
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { Url = "/Home/Index" }
                    };
                }
                else
                {
                    filterContext.Result = new RedirectResult("/Home/Index");
                    base.HandleUnauthorizedRequest(filterContext);
                }

            }
        }
    }
}