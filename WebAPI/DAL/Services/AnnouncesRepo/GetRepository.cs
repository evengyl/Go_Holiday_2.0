using DAL.IRepositories;
using DAL.Models.Announces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL.Services.AnnouncesRepo
{
    public class GetRepository : Services, IAnnouncesGet
    {
        public Announces Get(int AnnID)
        {
            Announces GetAnnounces = new Announces();

            using (SqlCommand commander = new SqlCommand("SP_get_announce_by_AnnID", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;

                commander.Parameters.AddWithValue("AnnID", AnnID);

                using (SqlDataReader reader = commander.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        GetAnnounces.AnnID = (int)reader["AnnID"];
                        GetAnnounces.Name = reader["Name"] == DBNull.Value ? string.Empty : (string)reader["Name"];
                        GetAnnounces.SubName = reader["SubName"] == DBNull.Value ? string.Empty : (string)reader["SubName"];
                        GetAnnounces.Desc = reader["Desc"] == DBNull.Value ? string.Empty : (string)reader["Desc"];
                        GetAnnounces.UserID = reader["UserID"] == DBNull.Value ? 0 : (int)reader["UserID"];
                        GetAnnounces.StartDate = reader["StartDate"] == DBNull.Value ? DateTime.Now : (DateTime)reader["StartDate"];
                        GetAnnounces.EndDate = reader["EndDate"] == DBNull.Value ? DateTime.Now : (DateTime)reader["EndDate"];
                        GetAnnounces.Vues = reader["Vues"] == DBNull.Value ? 0 : (int)reader["Vues"];
                        GetAnnounces.UserValid = reader["UserValid"] == DBNull.Value ? false : (bool)reader["UserValid"];
                        GetAnnounces.AdminValid = reader["AdminValid"] == DBNull.Value ? false : (bool)reader["AdminValid"];
                        GetAnnounces.CreateDate = reader["CreateDate"] == DBNull.Value ? DateTime.Now : (DateTime)reader["CreateDate"];
                        GetAnnounces.AddressPays = reader["AddressPays"] == DBNull.Value ? string.Empty : (string)reader["AddressPays"];
                        GetAnnounces.AddressVille = reader["AddressVille"] == DBNull.Value ? string.Empty : (string)reader["AddressVille"];
                        GetAnnounces.AddressCodePostal = reader["AddressCodePostal"] == DBNull.Value ? string.Empty : (string)reader["AddressCodePostal"];
                        GetAnnounces.AddressRue = reader["AddressRue"] == DBNull.Value ? string.Empty : (string)reader["AddressRue"];
                        GetAnnounces.AddressNumero = reader["AddressNumero"] == DBNull.Value ? string.Empty : (string)reader["AddressNumero"];


                    }
                }

            }

            GetAnnounces.ListSport = GetSport(AnnID);
            GetAnnounces.ListActivity = GetActivity(AnnID);
            GetAnnounces.ListCommoditer = GetCommoditer(AnnID);
            GetAnnounces.ListTypeHoliday = GetTypeHoliday(AnnID);
            GetAnnounces.TypeHabitat = GetTypeHabitat(AnnID);

            return GetAnnounces;
        }



        public List<Announces> GetAll()
        {
            List<Announces> GetALLAnnounces = new List<Announces>();

            using (SqlCommand commander = new SqlCommand("SP_get_announce_by_AnnID", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = commander.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GetALLAnnounces.Add(
                            new Announces
                            {
                                AnnID = (int)reader["AnnID"],
                                Name = reader["Name"] == DBNull.Value ? string.Empty : (string)reader["Name"],
                                SubName = reader["SubName"] == DBNull.Value ? string.Empty : (string)reader["SubName"],
                                Desc = reader["Desc"] == DBNull.Value ? string.Empty : (string)reader["Desc"],
                                UserID = reader["UserID"] == DBNull.Value ? 0 : (int)reader["UserID"],
                                StartDate = reader["StartDate"] == DBNull.Value ? DateTime.Now : (DateTime)reader["StartDate"],
                                EndDate = reader["EndDate"] == DBNull.Value ? DateTime.Now : (DateTime)reader["EndDate"],
                                Vues = reader["Vues"] == DBNull.Value ? 0 : (int)reader["Vues"],
                                UserValid = reader["UserValid"] == DBNull.Value ? false : (bool)reader["UserValid"],
                                AdminValid = reader["AdminValid"] == DBNull.Value ? false : (bool)reader["AdminValid"],
                                CreateDate = reader["CreateDate"] == DBNull.Value ? DateTime.Now : (DateTime)reader["CreateDate"],
                                AddressPays = reader["AddressPays"] == DBNull.Value ? string.Empty : (string)reader["AddressPays"],
                                AddressVille = reader["AddressVille"] == DBNull.Value ? string.Empty : (string)reader["AddressVille"],
                                AddressCodePostal = reader["AddressCodePostal"] == DBNull.Value ? string.Empty : (string)reader["AddressCodePostal"],
                                AddressRue = reader["AddressRue"] == DBNull.Value ? string.Empty : (string)reader["AddressRue"],
                                AddressNumero = reader["AddressNumero"] == DBNull.Value ? string.Empty : (string)reader["AddressNumero"],
                            }
                        );

                    }
                }
                return GetALLAnnounces;
            }
        }




        public List<Sport> GetSport(int AnnID)
        {
            List<Sport> GetListSport = new List<Sport>();


            connection.Close();
            connection.Open();
            using (SqlCommand commander = new SqlCommand("SP_get_ListSport_by_AnnID", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;
                commander.Parameters.AddWithValue("AnnID", AnnID);


                using (SqlDataReader reader = commander.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GetListSport.Add(
                            new Sport
                            {
                                SportID = (int)reader["SportID"],
                                Name = reader["Name"] == DBNull.Value ? string.Empty : (string)reader["Name"],
                                Desc = reader["Desc"] == DBNull.Value ? string.Empty : (string)reader["Desc"]
                            }
                        );
                    }

                }
            }
            return GetListSport;
        }


        public List<Activity> GetActivity(int AnnID)
        {
            List<Activity> GetListActivity = new List<Activity>();

            connection.Close();
            connection.Open();
            using (SqlCommand commander = new SqlCommand("SP_get_ListActivity_by_AnnID", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;
                commander.Parameters.AddWithValue("AnnID", AnnID);

                using (SqlDataReader reader = commander.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        GetListActivity.Add(
                            new Activity
                            {
                                ActivityID = (int)reader["ActivityID"],
                                Name = reader["Name"] == DBNull.Value ? string.Empty : (string)reader["Name"],
                                Desc = reader["Desc"] == DBNull.Value ? string.Empty : (string)reader["Desc"]
                            }
                        );
                    }
                    else
                    {
                        GetListActivity.Add(
                            new Activity()
                        );
                    }
                }

            }
            return GetListActivity;
        }


        public List<Commoditer> GetCommoditer(int AnnID)
        {
            List<Commoditer> GetListCommoditer = new List<Commoditer>();

            connection.Close();
            connection.Open();
            using (SqlCommand commander = new SqlCommand("SP_get_ListCommoditer_by_AnnID", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;
                commander.Parameters.AddWithValue("AnnID", AnnID);


                using (SqlDataReader reader = commander.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GetListCommoditer.Add(
                            new Commoditer
                            {
                                ComID = (int)reader["ComID"],
                                Name = reader["Name"] == DBNull.Value ? string.Empty : (string)reader["Name"],
                                Text = reader["Text"] == DBNull.Value ? string.Empty : (string)reader["Text"],
                                Icon = reader["Icon"] == DBNull.Value ? string.Empty : (string)reader["Icon"]
                            }
                        );
                    }
                }
            }
            return GetListCommoditer;
        }


        public TypeHabitat GetTypeHabitat(int AnnID)
        {
            TypeHabitat GetHabitat = new TypeHabitat();

            connection.Close();
            connection.Open();
            using (SqlCommand commander = new SqlCommand("SP_get_TypeHabitat_by_AnnID", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;
                commander.Parameters.AddWithValue("AnnID", AnnID);


                using (SqlDataReader reader = commander.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GetHabitat = new TypeHabitat
                        {
                            TypeID = (int)reader["TypeID"],
                            Name = reader["Name"] == DBNull.Value ? string.Empty : (string)reader["Name"],
                            Image = reader["Image"] == DBNull.Value ? string.Empty : (string)reader["Image"],
                            Text = reader["Text"] == DBNull.Value ? string.Empty : (string)reader["Text"]
                        };
                    }
                }
            }
            return GetHabitat;
        }


        public List<TypeHoliday> GetTypeHoliday(int AnnID)
        {
            List<TypeHoliday> GetListTypeHoliday = new List<TypeHoliday>();

            connection.Close();
            connection.Open();
            using (SqlCommand commander = new SqlCommand("SP_get_TypeHoliday_by_AnnID", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;
                commander.Parameters.AddWithValue("AnnID", AnnID);


                using (SqlDataReader reader = commander.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GetListTypeHoliday.Add(
                            new TypeHoliday
                            {
                                TypeID = (int)reader["TypeID"],
                                Name = reader["Name"] == DBNull.Value ? string.Empty : (string)reader["Name"],
                                IconDiv = reader["IconDiv"] == DBNull.Value ? string.Empty : (string)reader["IconDiv"],
                                Image = reader["Image"] == DBNull.Value ? string.Empty : (string)reader["Image"],
                                Text = reader["Text"] == DBNull.Value ? string.Empty : (string)reader["Text"]
                            }
                        );
                    }
                }
            }
            return GetListTypeHoliday;
        }
    }
}
