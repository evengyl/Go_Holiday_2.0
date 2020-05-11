using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Mappers
{
    public static class UserCreate_TO_UserDal
    {
        public static LoginDAL UserToDAL(this LoginCreate UserCreateForm)
        {
            return new LoginDAL
            {
                Login = UserCreateForm.Login,
                Password = UserCreateForm.Password,
                Name = UserCreateForm.Name,
                LastName = UserCreateForm.LastName
            };
        }
    }
}
