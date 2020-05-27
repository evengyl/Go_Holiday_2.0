using DAL.Models.Announces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.IRepositories
{
    public interface IAnnouncesGet
    {
        Announces Get(int AnnID);
        List<Activity> GetActivity(int AnnID);
        List<Announces> GetAll();
        List<Commoditer> GetCommoditer(int AnnID);
        List<Sport> GetSport(int AnnID);
        TypeHabitat GetTypeHabitat(int AnnID);
        List<TypeHoliday> GetTypeHoliday(int AnnID);
    }
}
