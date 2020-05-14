using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using WebApplication1.Session;

namespace WebApplication1.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AnonymousRequiredAttribute : TypeFilterAttribute
    {
        public AnonymousRequiredAttribute() : base(typeof(AnonymousRequiredFilter))
        {

        }
    }

    internal class AnonymousRequiredFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            ISessionManager sessionManager = (ISessionManager)context.HttpContext.RequestServices.GetService(typeof(ISessionManager));

            if(!(sessionManager.LoginUser is null))
            {
                //rediriger vers la page des todo quand on a réussi a se logger
                context.Result = new RedirectToActionResult("List", "Todo", null);
            }
        }
    }
}
