using System.IO;

using ModelsView_Forms = Go_Holiday_2._0.Models.ModelsView.Forms;
using ModelsView_Globals = Go_Holiday_2._0.Models.ModelsView.Globals;
using ModelsView_View = Go_Holiday_2._0.Models.ModelsView.Views;

using Go_Holiday_2._0.Utils.Attributes;
using Go_Holiday_2._0.Utils.Controller.API;
using Go_Holiday_2._0.Utils.Controller.API.Login;
using Go_Holiday_2._0.Utils.Mappers;
using Go_Holiday_2._0.Utils.Security;
using Go_Holiday_2._0.Utils.Session;
using Microsoft.AspNetCore.Mvc;



namespace Go_Holiday_2._0.Controllers.Profil
{
    [ConnectedRequired]
    public class MyProfilController : Controller
    {
        private IControllerAPI _controllerAPI;
        private CryptingRSA _cryptingRSA;
        private ISessionManager _sessionManager;
        private EditUserSystemAPI _editUserSystemAPI;

        private ModelsView_Globals.UserGlobal _userGlobal;

        public MyProfilController(IControllerAPI controllerAPI, CryptingRSA cryptingRSA, ISessionManager sessionManager, EditUserSystemAPI editUserSystemAPI)
        {
            _controllerAPI = controllerAPI;
            _editUserSystemAPI = editUserSystemAPI;
            _cryptingRSA = cryptingRSA;
            _sessionManager = sessionManager;

            _userGlobal = new ModelsView_Globals.UserGlobal();

            /* méthode */
            
            


        }



        // POST: User/EditProfil
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ConnectedRequired]
        public IActionResult EditProfil(ModelsView_Forms.UserInfos userInfos)
        {
            if (ModelState.IsValid)
            {
                _editUserSystemAPI.EditUser(userInfos.UserInfos_WebToApi(_sessionManager.UserID));
            }
        
            return RedirectToAction("Index");
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