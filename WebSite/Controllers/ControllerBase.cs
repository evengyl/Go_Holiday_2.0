using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Attributes.Action;
using WebApplication1.Session;

namespace WebApplication1.Controllers
{
    [IsLoggedAction]
    //intercepte lors de l'héritage des controller de la class Controller, viens mettre ceci avant.
    //et ici il faudra être is logged pour acceder a la SessionManager
    //c'est riky de sécurité, pas forcément besoin, on peux jsute passer l'injection  de dépendance a chaque controller qui a besoin de la session...
    
    public class ControllerBase : Controller
    {
        protected internal ISessionManager SessionManager { get; private set;}

        public ControllerBase(ISessionManager _sessionManager)
        {
            SessionManager = _sessionManager;
        }
    }
}
