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

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            Session = httpContextAccessor.HttpContext.Session;
        }


        public int UserID
        {
            get { return (Session.GetInt32(nameof(UserID)).HasValue) ? Session.GetInt32(nameof(UserID)).Value : -1; }
            set { Session.SetInt32(nameof(UserID), value); }
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

    }
}
