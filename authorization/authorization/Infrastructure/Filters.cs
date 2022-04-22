using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace authorization.Infrastructure
{
    public class UserAgentAsyncPageFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context,
                                                        ActionExecutionDelegate next)
        {
            string userAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();

            //Checking agent for IE and old Edge
            if (Regex.IsMatch(userAgent, "MSIE|Trident|Edge"))
                context.Result = new ObjectResult("Your browser is out of date!");
            else
                await next();  // transfer control to the next filter in the absence of other filters 
        }
    }

    public class AuthorizationFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context,
                                                        ActionExecutionDelegate next)
        {
            bool exists_current_user = false;
            if (context.HttpContext.Session.GetString("User") != null)
            {
                exists_current_user = true;
            }
            else
            {
                if (context.HttpContext.Request.Cookies.ContainsKey("LoginNameAuthorization"))
                {
                    var cookie = context.HttpContext.Request.Cookies["LoginNameAuthorization"];
                    context.HttpContext.Session.SetString("User", cookie);
                    exists_current_user = true;
                }
            }

            if (!exists_current_user)
                context.Result = new RedirectToRouteResult(new Microsoft.AspNetCore.Routing.RouteValueDictionary(new { controller = "Home", action = "Login" }));
            else
                await next();
        }
    }
}
