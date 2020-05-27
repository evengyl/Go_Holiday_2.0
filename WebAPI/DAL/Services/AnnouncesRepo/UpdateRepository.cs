using DAL.IRepositories;
using DAL.Models.Announces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Services.AnnouncesRepo
{
    public class UpdateRepository : Services, IAnnouncesUpdate
    {
        public void UpdateSport(List<Sport> ListSport, int AnnID)
        {
            using (SqlCommand commander = new SqlCommand("SP_delete_MTM_sport", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;
                commander.Parameters.AddWithValue("AnnID", AnnID);
                commander.ExecuteNonQuery();
            }

            foreach (Sport sport in ListSport)
            {
                using (SqlCommand commander = new SqlCommand("SP_update_MTM_sport", connection))
                {
                    commander.CommandType = CommandType.StoredProcedure;

                    commander.Parameters.AddWithValue("SportID", sport.SportID);
                    commander.Parameters.AddWithValue("AnnID", AnnID);

                    commander.ExecuteNonQuery();
                }
            }

        }

        public void UpdateActivity(List<Activity> ListActivity, int AnnID)
        {
            using (SqlCommand commander = new SqlCommand("SP_delete_MTM_activity", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;
                commander.Parameters.AddWithValue("AnnID", AnnID);
                commander.ExecuteNonQuery();
            }

            foreach (Activity activity in ListActivity)
            {
                using (SqlCommand commander = new SqlCommand("SP_update_MTM_activity", connection))
                {
                    commander.CommandType = CommandType.StoredProcedure;

                    commander.Parameters.AddWithValue("ActivityID", activity.ActivityID);
                    commander.Parameters.AddWithValue("AnnID", AnnID);

                    commander.ExecuteNonQuery();
                }
            }

        }

        public void UpdateCommoditer(List<Commoditer> ListCommoditer, int AnnID)
        {
            using (SqlCommand commander = new SqlCommand("SP_delete_MTM_commoditer", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;
                commander.Parameters.AddWithValue("AnnID", AnnID);
                commander.ExecuteNonQuery();
            }

            foreach (Commoditer commoditer in ListCommoditer)
            {
                using (SqlCommand commander = new SqlCommand("SP_update_MTM_commoditer", connection))
                {
                    commander.CommandType = CommandType.StoredProcedure;

                    commander.Parameters.AddWithValue("CommoditerID", commoditer.ComID);
                    commander.Parameters.AddWithValue("AnnID", AnnID);

                    commander.ExecuteNonQuery();
                }
            }
        }

        public void UpdateTypeHoliday(List<TypeHoliday> ListTypeHolidays, int AnnID)
        {
            using (SqlCommand commander = new SqlCommand("SP_delete_MTM_TypeHoliday", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;
                commander.Parameters.AddWithValue("AnnID", AnnID);
                commander.ExecuteNonQuery();
            }

            foreach (TypeHoliday holiday in ListTypeHolidays)
            {
                using (SqlCommand commander = new SqlCommand("SP_update_MTM_TypeHoliday", connection))
                {
                    commander.CommandType = CommandType.StoredProcedure;

                    commander.Parameters.AddWithValue("TypeHolidayID", holiday.TypeID);
                    commander.Parameters.AddWithValue("AnnID", AnnID);

                    commander.ExecuteNonQuery();
                }
            }
        }

        public void UpdateHabitat(TypeHabitat typeHabitat, int AnnID)
        {
            using (SqlCommand commander = new SqlCommand("SP_delete_MTM_TypeHabitat", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;
                commander.Parameters.AddWithValue("AnnID", AnnID);
                commander.ExecuteNonQuery();
            }

            using (SqlCommand commander = new SqlCommand("SP_update_MTM_TypeHabitat", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;

                commander.Parameters.AddWithValue("TypeHabitatID", typeHabitat.TypeID);
                commander.Parameters.AddWithValue("AnnID", AnnID);

                commander.ExecuteNonQuery();
            }
        }




        public void Update(Announces announce)
        {
            using (SqlCommand commander = new SqlCommand("SP_update_announce", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;

                commander.Parameters.AddWithValue("AnnID", announce.AnnID);
                commander.Parameters.AddWithValue("Name", announce.Name);
                commander.Parameters.AddWithValue("SubName", announce.SubName);
                commander.Parameters.AddWithValue("Desc", announce.Desc);
                commander.Parameters.AddWithValue("StartDate", announce.StartDate);
                commander.Parameters.AddWithValue("EndDate", announce.EndDate);
                commander.Parameters.AddWithValue("AddressPays", announce.AddressPays);
                commander.Parameters.AddWithValue("AddressVille", announce.AddressVille);
                commander.Parameters.AddWithValue("AddressRue", announce.AddressRue);
                commander.Parameters.AddWithValue("AddressCodePostal", announce.AddressCodePostal);
                commander.Parameters.AddWithValue("AddressNumero", announce.AddressNumero);

                commander.ExecuteNonQuery();
            }
        }
    }
}
