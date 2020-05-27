using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelsAPI = API_2.Models.Announces;
using ModelsDAL = DAL.Models.Announces;

namespace API_2._0.Mappers
{
    public static class MapperAnnounce
    {
        public static ModelsAPI.Announces DALToAPI(this ModelsDAL.Announces DALToAPI)
        {
            return new ModelsAPI.Announces
            {
                AnnID = DALToAPI.AnnID,
                Name = DALToAPI.Name,
                SubName = DALToAPI.SubName,
                Desc = DALToAPI.Desc,
                UserID = DALToAPI.UserID,
                StartDate = DALToAPI.StartDate,
                EndDate = DALToAPI.EndDate,
                Vues = DALToAPI.Vues,
                UserValid = DALToAPI.UserValid,
                AdminValid = DALToAPI.AdminValid,
                CreateDate = DALToAPI.CreateDate,
                AddressPays = DALToAPI.AddressPays,
                AddressVille = DALToAPI.AddressVille,
                AddressCodePostal = DALToAPI.AddressCodePostal,
                AddressRue = DALToAPI.AddressRue,
                AddressNumero = DALToAPI.AddressNumero,
            };
        }

        public static ModelsDAL.Announces APIToDAL(this ModelsAPI.Announces DALToAPI)
        {
            return new ModelsDAL.Announces
            {
                AnnID = DALToAPI.AnnID,
                Name = DALToAPI.Name,
                SubName = DALToAPI.SubName,
                Desc = DALToAPI.Desc,
                UserID = DALToAPI.UserID,
                StartDate = DALToAPI.StartDate,
                EndDate = DALToAPI.EndDate,
                Vues = DALToAPI.Vues,
                UserValid = DALToAPI.UserValid,
                AdminValid = DALToAPI.AdminValid,
                CreateDate = DALToAPI.CreateDate,
                AddressPays = DALToAPI.AddressPays,
                AddressVille = DALToAPI.AddressVille,
                AddressCodePostal = DALToAPI.AddressCodePostal,
                AddressRue = DALToAPI.AddressRue,
                AddressNumero = DALToAPI.AddressNumero,
            };
        }









        public static ModelsAPI.Activity DALToAPIActivity(this ModelsDAL.Activity DALToAPI)
        {
            return new ModelsAPI.Activity
            {
                ActivityID = DALToAPI.ActivityID,
                Name = DALToAPI.Name,
                Desc = DALToAPI.Desc
            };
        }

        public static ModelsDAL.Activity APIToDALActivity(this ModelsAPI.Activity DALToAPI)
        {
            return new ModelsDAL.Activity
            {
                ActivityID = DALToAPI.ActivityID,
                Name = DALToAPI.Name,
                Desc = DALToAPI.Desc
            };
        }









        public static ModelsAPI.Sport DALToAPISport(this ModelsDAL.Sport DALToAPI)
        {
            return new ModelsAPI.Sport
            {
                SportID = DALToAPI.SportID,
                Name = DALToAPI.Name,
                Desc = DALToAPI.Desc
            };
        }

        public static ModelsDAL.Sport APIToDALSport(this ModelsAPI.Sport DALToAPI)
        {
            return new ModelsDAL.Sport
            {
                SportID = DALToAPI.SportID,
                Name = DALToAPI.Name,
                Desc = DALToAPI.Desc
            };
        }











        public static ModelsAPI.Commoditer DALToAPICommoditer(this ModelsDAL.Commoditer DALToAPI)
        {
            return new ModelsAPI.Commoditer
            {
                ComID = DALToAPI.ComID,
                Name = DALToAPI.Name,
                Text = DALToAPI.Text,
                Icon = DALToAPI.Icon
            };
        }

        public static ModelsDAL.Commoditer APIToDALCommoditer(this ModelsAPI.Commoditer DALToAPI)
        {
            return new ModelsDAL.Commoditer
            {
                ComID = DALToAPI.ComID,
                Name = DALToAPI.Name,
                Text = DALToAPI.Text,
                Icon = DALToAPI.Icon
            };
        }







        public static ModelsAPI.TypeHoliday DALToAPITypeHoliday(this ModelsDAL.TypeHoliday DALToAPI)
        {
            return new ModelsAPI.TypeHoliday
            {
                TypeID = DALToAPI.TypeID,
                Name = DALToAPI.Name,
                IconDiv = DALToAPI.IconDiv,
                Image = DALToAPI.Image,
                Text = DALToAPI.Text
            };
        }

        public static ModelsDAL.TypeHoliday APIToDALTypeHoliday(this ModelsAPI.TypeHoliday DALToAPI)
        {
            return new ModelsDAL.TypeHoliday
            {
                TypeID = DALToAPI.TypeID,
                Name = DALToAPI.Name,
                IconDiv = DALToAPI.IconDiv,
                Image = DALToAPI.Image,
                Text = DALToAPI.Text
            };
        }







        public static ModelsAPI.TypeHabitat DALToAPITypeHabitat(this ModelsDAL.TypeHabitat DALToAPI)
        {
            return new ModelsAPI.TypeHabitat
            {
                TypeID = DALToAPI.TypeID,
                Name = DALToAPI.Name,
                Image = DALToAPI.Image,
                Text = DALToAPI.Text
            };
        }

        public static ModelsDAL.TypeHabitat APIToDALTypeHabitat(this ModelsAPI.TypeHabitat DALToAPI)
        {
            return new ModelsDAL.TypeHabitat
            {
                TypeID = DALToAPI.TypeID,
                Name = DALToAPI.Name,
                Image = DALToAPI.Image,
                Text = DALToAPI.Text
            };
        }
    }
}
