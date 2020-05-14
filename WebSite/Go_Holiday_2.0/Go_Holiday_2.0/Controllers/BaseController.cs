using Go_Holiday_2._0.Utils.Attributes.Action;
using Go_Holiday_2._0.Utils.Controller;
using Go_Holiday_2._0.Utils.Session;
using Microsoft.AspNetCore.Mvc;

namespace Go_Holiday_2._0.Controllers
{
    [IsLoggedAction]
    public class BaseController : Controller, ILoggedController
    {
        private ISessionManager _sessionManager;

        protected  ISessionManager SessionManager {
            get
            {
                return _sessionManager;
            }
            private set
            {
                _sessionManager = value;
            }
        }

        ISessionManager ILoggedController.SessionManager {
            get
            {
                return SessionManager;
            }
            set
            {
                SessionManager = value;
            }
        }


        //intercepte lors de l'héritage des controller de la class Controller, viens mettre ceci avant.
        public BaseController()
        {
        }
    }
}
