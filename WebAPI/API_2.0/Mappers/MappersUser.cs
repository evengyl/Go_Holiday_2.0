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
                Email = DALToAPI.Email
                /*AddressUser = new ModelsAPI.AddressUser
                {
                    Rue = DALToAPI.AddressUser.Rue,
                    Numero = DALToAPI.AddressUser.Numero,
                    CodePostal = DALToAPI.AddressUser.CodePostal,
                    Ville = DALToAPI.AddressUser.Ville,
                    Pays = DALToAPI.AddressUser.Pays
                },
                ComplementUser = new ModelsAPI.ComplementUser
                {
                    Gsm = DALToAPI.ComplementUser.Gsm,
                    Phone = DALToAPI.ComplementUser.Phone,
                    Benefice = DALToAPI.ComplementUser.Benefice,
                    TotalPrice_InLocate = DALToAPI.ComplementUser.TotalPrice_InLocate,
                    TotalPrice_InAttemps = DALToAPI.ComplementUser.TotalPrice_InAttemps
                }*/
            };
        }
    }
}
