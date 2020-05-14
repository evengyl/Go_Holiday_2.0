using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelAPI = Go_Holiday_2._0.Models.ModelsAPI;
using ModelWeb = Go_Holiday_2._0.Models;

namespace Go_Holiday_2._0.Utils.Mappers
{
    public static class UserSignUpToDAL
    {
        public static ModelAPI.UserAPI User_WebToApi(this ModelWeb.UserSignUp user)
        {
            return new ModelAPI.UserAPI
            {
                LastName = user.LastName,
                FirstName = user.FirstName,
                Email = user.Email,
                Password = user.Password
            };
        }
    }
}
