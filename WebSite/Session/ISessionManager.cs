namespace WebApplication1.Session
{
    public interface ISessionManager
    {
        int IdUser { get; set; }
        string LoginUser { get; set; }
        string NameUser { get; set; }
        string LastNameUser { get; set; }

        void Abandon();
    }
}