using Go_Holiday_2._0.Utils.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelAPI = Go_Holiday_2._0.Models.ModelsView.API;
using ModelWeb = Go_Holiday_2._0.Models.ModelsView.Forms;

namespace Go_Holiday_2._0.Utils.Mappers
{
    public static class UserInfos
    {
        public static ModelAPI.UserInfos UserInfos_WebToApi(this ModelWeb.UserInfos user, int UserID)
        {
            return new ModelAPI.UserInfos
            {
                UserID = UserID,
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

        public static ModelWeb.UserInfos UserInfos_ApiToWeb(this ModelAPI.UserInfos user)
        {
            return new ModelWeb.UserInfos
            {
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
