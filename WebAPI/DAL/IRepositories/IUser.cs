using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.IRepositories
{
    public interface IUser
    {
        User Login(User user);
        void DesactivateUser(int user_id);
        void ActivateUser(int user_id);
        void ChangePassword(int user_id, string password_decrypt);
    }
}
