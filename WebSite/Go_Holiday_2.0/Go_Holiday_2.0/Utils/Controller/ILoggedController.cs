using Go_Holiday_2._0.Utils.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Go_Holiday_2._0.Utils.Controller
{
    interface ILoggedController
    {
        public ISessionManager SessionManager {
            get; set; 
        }
    }
}
