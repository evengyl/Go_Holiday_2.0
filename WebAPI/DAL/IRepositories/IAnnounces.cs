using DAL.Models.Announces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.IRepositories
{
    public interface IAnnounces
    {
        public List<Sport> GetSport(int AnnID);
        public List<Activity> GetActivity(int AnnID);
        public List<Commoditer> GetCommoditer(int AnnID);
        public TypeHabitat GetTypeHabitat(int AnnID);
        public List<TypeHoliday> GetTypeHoliday(int AnnID);
        public int Create(Announces announce);
    }
}
