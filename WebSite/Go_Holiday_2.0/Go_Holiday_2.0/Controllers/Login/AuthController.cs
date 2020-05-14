using Go_Holiday_2._0.Models;
using Go_Holiday_2._0.Utils.Attributes;
using Go_Holiday_2._0.Utils.Controller.API;
using Go_Holiday_2._0.Utils.Controller.API.Login;
using Go_Holiday_2._0.Utils.Mappers;
using Go_Holiday_2._0.Utils.Security;
using Microsoft.AspNetCore.Mvc;

namespace Go_Holiday_2._0.Controllers.Login
{
    public class AuthController : BaseController
    {
        private IControllerAPI _controllerAPI;
        private CryptingRSA _cryptingRSA;
        private LoginSystemAPI _loginSystemAPI;
        private SignUpSystemAPI _signUpSystemAPI;
        public AuthController(IControllerAPI controllerAPI, CryptingRSA cryptingRSA, LoginSystemAPI loginSystemAPI, SignUpSystemAPI signUpSystemAPI)
        {
            _loginSystemAPI = loginSystemAPI;
            _signUpSystemAPI = signUpSystemAPI;
            _controllerAPI = controllerAPI;
            _cryptingRSA = cryptingRSA;
        }




        [NotConnectedRequired]
        public IActionResult SignIn()
        {
            return View();
        }


        [NotConnectedRequired]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(UserSignIn user)
        {
            if (ModelState.IsValid)
            {
                string publicKey = _controllerAPI.GetPublicKey();

                user.Password = _cryptingRSA.Encrypt(user.Password, publicKey);

                UserLogin userLogin = _loginSystemAPI.Login<UserSignIn, UserLogin>(user);

                if (userLogin.Email == user.Email)
                {
                    SessionManager.UserID = userLogin.UserID;
                    SessionManager.Email = userLogin.Email;
                    SessionManager.LastName = userLogin.LastName;
                    SessionManager.FirstName = userLogin.FirstName;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Ce login n'existe pas ou le mot de passe n'est pas correct.");
                    return View();
                }
            }

            return RedirectToAction("Index", "Home");
        }


        //Partie pour le sign up

        [NotConnectedRequired]
        public IActionResult SignUp()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [NotConnectedRequired]
        public IActionResult SignUp(UserSignUp userSignUp)
        {
            if (ModelState.IsValid)
            {
                int userID = (int)_signUpSystemAPI.VerifyEmail(userSignUp.Email);


                if (userID != 0)
                {
                    ModelState.AddModelError(string.Empty, "Cette adresse Email est déjà utilisée.");
                    return View();
                }
                else
                {
                    string publicKey = _controllerAPI.GetPublicKey();

                    userSignUp.Password = _cryptingRSA.Encrypt(userSignUp.Password, publicKey);

                    _controllerAPI.PostAPI("User/Register", userSignUp.User_WebToApi());
                    ViewBag.Message = "Merci pour votre inscription, Bienvenue!";
                    return View("SignUpSuccess");
                }
            }
            else
                return View();
        }



        public IActionResult Index() { return View(); }


        [ConnectedRequired]
        public IActionResult Logout()
        {
            SessionManager.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}