using DAL.IRepositories;
using DAL.Models.Announces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Services.AnnouncesRepo
{
    public class CreateRepository : Services, IAnnouncesCreate
    {
        public void PostSport(List<Sport> ListSport, int AnnID)
        {
            foreach (Sport sport in ListSport)
            {
                using (SqlCommand commander = new SqlCommand("SP_create_MTM_sport", connection))
                {
                    commander.CommandType = CommandType.StoredProcedure;

                    commander.Parameters.AddWithValue("SportID", sport.SportID);
                    commander.Parameters.AddWithValue("AnnID", AnnID);

                    commander.ExecuteNonQuery();
                }
            }

        }

        public void PostActivity(List<Activity> ListActivity, int AnnID)
        {

            foreach (Activity activity in ListActivity)
            {
                using (SqlCommand commander = new SqlCommand("SP_create_MTM_activity", connection))
                {
                    commander.CommandType = CommandType.StoredProcedure;

                    commander.Parameters.AddWithValue("ActivityID", activity.ActivityID);
                    commander.Parameters.AddWithValue("AnnID", AnnID);

                    commander.ExecuteNonQuery();
                }
            }

        }

        public void PostCommoditer(List<Commoditer> ListCommoditer, int AnnID)
        {
            foreach (Commoditer commoditer in ListCommoditer)
            {
                using (SqlCommand commander = new SqlCommand("SP_create_MTM_commoditer", connection))
                {
                    commander.CommandType = CommandType.StoredProcedure;

                    commander.Parameters.AddWithValue("CommoditerID", commoditer.ComID);
                    commander.Parameters.AddWithValue("AnnID", AnnID);

                    commander.ExecuteNonQuery();
                }
            }
        }

        public void PostTypeHoliday(List<TypeHoliday> ListTypeHolidays, int AnnID)
        {
            foreach (TypeHoliday holiday in ListTypeHolidays)
            {
                using (SqlCommand commander = new SqlCommand("SP_create_MTM_TypeHoliday", connection))
                {
                    commander.CommandType = CommandType.StoredProcedure;

                    commander.Parameters.AddWithValue("TypeHolidayID", holiday.TypeID);
                    commander.Parameters.AddWithValue("AnnID", AnnID);

                    commander.ExecuteNonQuery();
                }
            }
        }

        public void PostHabitat(TypeHabitat typeHabitat, int AnnID)
        {
            using (SqlCommand commander = new SqlCommand("SP_create_MTM_TypeHabitat", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;

                commander.Parameters.AddWithValue("TypeHabitatID", typeHabitat.TypeID);
                commander.Parameters.AddWithValue("AnnID", AnnID);

                commander.ExecuteNonQuery();
            }
        }




        public int Create(Announces announce)
        {
            using (SqlCommand commander = new SqlCommand("SP_create_announce", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;

                commander.Parameters.AddWithValue("Name", announce.Name);
                commander.Parameters.AddWithValue("SubName", announce.SubName);
                commander.Parameters.AddWithValue("Desc", announce.Desc);
                commander.Parameters.AddWithValue("UserID", announce.UserID);
                commander.Parameters.AddWithValue("StartDate", announce.StartDate);
                commander.Parameters.AddWithValue("EndDate", announce.EndDate);
                commander.Parameters.AddWithValue("Vues", announce.Vues);
                commander.Parameters.AddWithValue("UserValid", announce.UserValid);
                commander.Parameters.AddWithValue("AdminValid", announce.AdminValid);
                commander.Parameters.AddWithValue("CreateDate", announce.CreateDate);
                commander.Parameters.AddWithValue("AddressPays", announce.AddressPays);
                commander.Parameters.AddWithValue("AddressVille", announce.AddressVille);
                commander.Parameters.AddWithValue("AddressRue", announce.AddressRue);
                commander.Parameters.AddWithValue("AddressCodePostal", announce.AddressCodePostal);
                commander.Parameters.AddWithValue("AddressNumero", announce.AddressNumero);

                int NewAnnID = (int)commander.ExecuteScalar();
                return NewAnnID;
                //on peux passer au mtm de tout le reste
            }
        }

    }
}
