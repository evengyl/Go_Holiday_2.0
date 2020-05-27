using DAL.Models.Announces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.IRepositories
{
    public interface IAnnouncesCreate
    {
        int Create(Announces announce);
        void PostActivity(List<Activity> ListActivity, int AnnID);
        void PostCommoditer(List<Commoditer> ListCommoditer, int AnnID);
        void PostHabitat(TypeHabitat typeHabitat, int AnnID);
        void PostSport(List<Sport> ListSport, int AnnID);
        void PostTypeHoliday(List<TypeHoliday> ListTypeHolidays, int AnnID);
    }
}
