using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Controllers;

namespace WebApplication1.Attributes.Action
{
    [AttributeUsage(AttributeTargets.Class |AttributeTargets.Method, AllowMultiple =false, Inherited =true)]
    public class IsLoggedAction : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ControllerBase controller = (ControllerBase)context.Controller;

            //variable global a la session
            if (controller.SessionManager.LoginUser is null)
                controller.ViewBag.IsLogged = false;
            else
            {
                controller.ViewBag.IsLogged = true;
                controller.ViewBag.Login = controller.SessionManager.LoginUser;
                controller.ViewBag.IdUser = controller.SessionManager.IdUser;
            }
            //end
        }
    }
}
