using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Go_Holiday_2._0.Utils.Session;
using Go_Holiday_2._0.Utils.Controller;

namespace Go_Holiday_2._0.Utils.Attributes.Action
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class IsLoggedAction : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ISessionManager SessionManager = (ISessionManager)context.HttpContext.RequestServices.GetService(typeof(ISessionManager));

            if(context.Controller is ILoggedController controller)
            {
                controller.SessionManager = SessionManager;
            }
        }
    }
}
