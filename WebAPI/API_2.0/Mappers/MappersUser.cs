using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ModelsDAL = DAL.Models;
using ModelsAPI = API_2.Models;

namespace API_2.Mappers
{
    public static class MappersUser
    {
        public static ModelsAPI.User DALToAPI(this ModelsDAL.User DALToAPI)
        {
            return new ModelsAPI.User
            {
                UserID = DALToAPI.UserID,
                LastName = DALToAPI.LastName,
                FirstName = DALToAPI.FirstName,
                Email = DALToAPI.Email,
                TypeUser = DALToAPI.TypeUser
            };
        }
    }
}
