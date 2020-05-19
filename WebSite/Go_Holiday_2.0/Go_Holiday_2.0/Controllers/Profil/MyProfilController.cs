using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Go_Holiday_2._0.Models;
using Go_Holiday_2._0.Utils.Controller.API;
using Go_Holiday_2._0.Utils.Security;
using Go_Holiday_2._0.Utils.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Go_Holiday_2._0.Controllers.Profil
{
    public class MyProfilController : Controller
    {
        private IControllerAPI _controllerAPI;
        private CryptingRSA _cryptingRSA;
        private ISessionManager _sessionManager;


        private UserInfos UI;



        public MyProfilController(IControllerAPI controllerAPI, CryptingRSA cryptingRSA, ISessionManager sessionManager)
        {
            _controllerAPI = controllerAPI;
            _cryptingRSA = cryptingRSA;
            _sessionManager = sessionManager;
            
            UI = new UserInfos();
        }
        
        
        public IActionResult Index()
        {
            UserInfos UI = _sessionManager.GetInfosUser();
            ViewBag.UI = UI;
            return View();
        }

       
    }
}