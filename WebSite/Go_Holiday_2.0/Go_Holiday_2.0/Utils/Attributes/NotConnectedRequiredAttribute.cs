using Go_Holiday_2._0.Utils.Session;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;


namespace Go_Holiday_2._0.Utils.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class NotConnectedRequiredAttribute : TypeFilterAttribute
    {
        public NotConnectedRequiredAttribute() : base(typeof(NotConnectedRequiredFilter))
        {

        }
    }

    internal class NotConnectedRequiredFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            ISessionManager sessionManager = (ISessionManager)context.HttpContext.RequestServices.GetService(typeof(ISessionManager));

            if (sessionManager.LastName != null)
            {
                //si pas logger et que c'est demander grace a l'attribut ici, renvoi vers la page login
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
            else
            {
                //ok action peux être faite
            }
        }
    }
}
