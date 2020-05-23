using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsDAL = DAL.Models;
using ModelsAPI = API_2.Models;

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

        public static ModelsAPI.UserInfos UserInfos_DALToApi(this ModelsDAL.UserInfos user)
        {
            return new ModelsAPI.UserInfos
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
