using Microsoft.AspNetCore.Mvc;
using WebApplication1.Attributes;
using WebApplication1.Models;
using WebApplication1.Session;
using WebApplication1.Utils;
using WebApplication1.Mappers;
using System;
using WebApplication1.Utils.Security.RSA_Cryptography;

namespace WebApplication1.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IControllerAPI _controllerAPI;
        private readonly Crypting _crypPassword;
        public UserController(IControllerAPI controllerAPI, ISessionManager sessionManager, Crypting crypPassword) : base(sessionManager)
        {
            _controllerAPI = controllerAPI;
            _crypPassword = crypPassword;
        }

        // GET: UserCreate/Create
        [AnonymousRequired]
        public ActionResult Create()
        {
            return View(new LoginCreate());
        }

        // POST: UserCreate/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AnonymousRequired]
        public ActionResult Create(LoginCreate loginCreate)
        {
            if (ModelState.IsValid)
            {
                LoginCreate testLogin = _controllerAPI.Login<LoginCreate>(loginCreate);


                if (testLogin.Login != null)
                {
                    ModelState.AddModelError(string.Empty, "Ce login Existe déjà.");
                    return View(loginCreate);
                }
                else
                {
                    string publicKey = _controllerAPI.GetPublicKey();

                    loginCreate.Password = _crypPassword.Encrypt(loginCreate.Password, publicKey);
                    
                    _controllerAPI.PostAPI("UserTodo/Post", loginCreate.UserToDAL());
                    ViewBag.Message = "Merci pour votre inscription, Bienvenue!";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
                return View(loginCreate);
        }



        [AnonymousRequired]
        public ActionResult Login()
        {
            return View();
        }

        // POST: UserLogin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AnonymousRequired]
        public ActionResult Login(LoginConnect user)
        {
            if (ModelState.IsValid)
            {
                string publicKey = _controllerAPI.GetPublicKey();

                user.Password = _crypPassword.Encrypt(user.Password, publicKey);

                LoginConnect userLogin = _controllerAPI.Login<LoginConnect>(user);

                if (userLogin.Login == user.Login)
                {
                    SessionManager.LoginUser = userLogin.Login;
                    SessionManager.IdUser = userLogin.id;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Ce login n'existe pas ou le mot de passe n'est pas correct.");
                    return View(user);
                }

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Formulaire non valide");
                return View(user);
            }
        }

        [LoggedRequired]
        public IActionResult Logout()
        {
            SessionManager.Abandon();
            return RedirectToAction("Login", "User");
        }
    }
}