using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Go_Holiday_2._0.Models;
using Go_Holiday_2._0.Models.ModelsView.Forms;
using Go_Holiday_2._0.Models.ModelsView.Globals;
using Go_Holiday_2._0.Models.ModelsView.Partials;
using Go_Holiday_2._0.Utils.Attributes;
using Go_Holiday_2._0.Utils.Controller.API;
using Go_Holiday_2._0.Utils.Security;
using Go_Holiday_2._0.Utils.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace Go_Holiday_2._0.Controllers.Profil
{
    [ConnectedRequired]
    public class MyProfilController : Controller
    {
        private IControllerAPI _controllerAPI;
        private CryptingRSA _cryptingRSA;
        private ISessionManager _sessionManager;


        private UserGlobal _userGlobal;
#pragma warning disable CS0169 // Le champ 'MyProfilController._signUpSystemAPI' n'est jamais utilisé
        private object _signUpSystemAPI;
#pragma warning restore CS0169 // Le champ 'MyProfilController._signUpSystemAPI' n'est jamais utilisé

        public MyProfilController(IControllerAPI controllerAPI, CryptingRSA cryptingRSA, ISessionManager sessionManager)
        {
            _controllerAPI = controllerAPI;
            _cryptingRSA = cryptingRSA;
            _sessionManager = sessionManager;

            _userGlobal = new UserGlobal();

            /* méthode */
            
            


        }



        // POST: User/EditProfil
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ConnectedRequired]
        public IActionResult EditProfil(UserInfos userInfos)
        {
            if (ModelState.IsValid)
            {
                    //_controllerAPI.PutAPI("User/Update", userInfos);
            }
        
            return View();
        }


        public IActionResult Index()
        {
            _userGlobal.UserInfos = _sessionManager.GetInfosUser();
            GetBackgroundProfilList();

            return View(_userGlobal);
        }

        private void GetBackgroundProfilList()
        {
            DirectoryInfo dir = new DirectoryInfo(@"wwwroot/data/images/background_profil");
            FileInfo[] fichiers = dir.GetFiles();


            foreach (FileInfo fichier in fichiers)
            {
                _userGlobal.BackgroundProfil.Url.Add(fichier.FullName);
                _userGlobal.BackgroundProfil.ShortUrl.Add(fichier.Name);
            }
        }
    }
}