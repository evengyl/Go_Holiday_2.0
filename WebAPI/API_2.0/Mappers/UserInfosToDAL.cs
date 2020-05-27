using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsDAL = DAL.Models.Users;
using ModelsAPI = API_2.Models.Users;

namespace API_2.Mappers
{
    public static class UserInfosToDAL
    {
        public static ModelsDAL.UserInfos UserInfos_ApiToDAL(this ModelsAPI.UserInfos user)
        {
            return new ModelsDAL.UserInfos
            {
                UserID = user.UserID,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Email = user.Email,
                Rue = user.Rue,
                Ville = user.Ville,
                Pays = user.Pays,
                Numero = user.Numero,
                CodePostal = user.CodePostal,
                Gsm = user.Gsm,
                Phone = user.Phone
            };
        }

       
    }
}
