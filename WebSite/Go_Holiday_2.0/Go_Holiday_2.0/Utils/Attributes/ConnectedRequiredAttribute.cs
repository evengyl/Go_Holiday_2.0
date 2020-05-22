using Go_Holiday_2._0.Utils.Session;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Go_Holiday_2._0.Utils.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class ConnectedRequiredAttribute : TypeFilterAttribute
    {
        public ConnectedRequiredAttribute() : base(typeof(ConnectedRequiredFilter))
        {

        }
    }

    internal class ConnectedRequiredFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            ISessionManager sessionManager = (ISessionManager)context.HttpContext.RequestServices.GetService(typeof(ISessionManager));

            if (sessionManager.LastName is null)
            {
                //redirection vers la page d'acceuil qu'on l'on fait une action ou l'on devrais absolument être déconnecter
                //très rare, a mon avis uniquement pour éviter le force brut sur la page login et create account si connecter
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }
}
