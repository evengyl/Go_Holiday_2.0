using Go_Holiday_2._0.Models;
using Go_Holiday_2._0.Utils.Controller.API;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Go_Holiday_2._0.Utils.Session
{
    public class SessionManager : ISessionManager
    {
        private ISession Session { get; }
        private IControllerAPI _controllerAPI;

        public SessionManager(IHttpContextAccessor httpContextAccessor, IControllerAPI controllerAPI)
        {
            Session = httpContextAccessor.HttpContext.Session;
            _controllerAPI = controllerAPI;
        }


        public int UserID
        {
            get { return (Session.GetInt32(nameof(UserID)).HasValue) ? Session.GetInt32(nameof(UserID)).Value : -1; }
            set { Session.SetInt32(nameof(UserID), value); }
        }

        public int TypeUser
        {
            get { return (Session.GetInt32(nameof(TypeUser)).HasValue) ? Session.GetInt32(nameof(TypeUser)).Value : -1; }
            set { Session.SetInt32(nameof(TypeUser), value); }
        }

        public string LastName
        {
            get { return Session.GetString(nameof(LastName)); }
            set { Session.SetString(nameof(LastName), value); }
        }
        public string FirstName
        {
            get { return Session.GetString(nameof(FirstName)); }
            set { Session.SetString(nameof(FirstName), value); }
        }
        public string Email
        {
            get { return Session.GetString(nameof(Email)); }
            set { Session.SetString(nameof(Email), value); }
        }

        public void Abandon()
        {
            Session.Clear();
        }


        /* Méthode liée à la session */


        public UserInfos GetInfosUser()
        {
            if (UserID == -1)
                return null;
            else
            {
                UserInfos userInfos = _controllerAPI.GetOneAPI<UserInfos>("User/Get", UserID);
                return userInfos;
            }


        }

    }
}
