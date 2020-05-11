using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using WebApplication1.Session;

namespace WebApplication1.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class LoggedRequiredAttribute : TypeFilterAttribute
    {
        public LoggedRequiredAttribute() : base(typeof(LoggedRequiredFilter))
        {

        }
    }

    internal class LoggedRequiredFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            ISessionManager sessionManager = (ISessionManager)context.HttpContext.RequestServices.GetService(typeof(ISessionManager));

            if(sessionManager.LoginUser is null)
            {
                context.Result = new RedirectToActionResult("Login", "User", null);
            }
        }
    }
}
