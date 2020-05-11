
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Session
{
    public class SessionManager : ISessionManager
    {
        private ISession Session { get; }
        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            Session = httpContextAccessor.HttpContext.Session;
        }



        public int IdUser
        {
            get { return (Session.GetInt32(nameof(IdUser)).HasValue) ? Session.GetInt32(nameof(IdUser)).Value : -1; }
            set { Session.SetInt32(nameof(IdUser), value); }
        }
        public string LoginUser
        {
            get { return Session.GetString(nameof(LoginUser)); }
            set { Session.SetString(nameof(LoginUser), value); }
        }
        public string NameUser
        {
            get { return Session.GetString(nameof(NameUser)); }
            set { Session.SetString(nameof(NameUser), value); }
        }
        public string LastNameUser
        {
            get { return Session.GetString(nameof(LastNameUser)); }
            set { Session.SetString(nameof(LastNameUser), value); }
        }

        public void Abandon()
        {
            Session.Clear();
        }
    }
}
