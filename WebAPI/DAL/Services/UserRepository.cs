using DAL.IRepositories;
using DAL.Models.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Services
{
    public class UserRepository : Services, IRepository<UserALL>, IUser
    {
        

        public List<UserALL> GetAll()
        {
            List<UserALL> ListUser = new List<UserALL>();

            using (SqlCommand commander = connection.CreateCommand())
            {
                commander.CommandText = "SELECT * FROM [UserInfos]";

                using (SqlDataReader reader = commander.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListUser.Add(new UserALL
                        {
                            UserID = (int)reader["UserID"],
                            LastName = (string)reader["LastName"],
                            FirstName = (string)reader["FirstName"],
                            Email = (string)reader["Email"],
                            Rue = (string)reader["Rue"],
                            Numero = (string)reader["Numero"],
                            CodePostal = (int)reader["CodePostal"],
                            Ville = (string)reader["Ville"],
                            Pays = (string)reader["Pays"],
                            Gsm = (string)reader["Gsm"],
                            Phone = (string)reader["Phone"]
                        });
                    }
                    return ListUser;
                }
            }
        }
        public UserALL Get(int user_id)
        {
            using (SqlCommand commander = connection.CreateCommand())
            {
                commander.CommandText = "SELECT * FROM [UserInfos] WHERE UserID = @id";
                commander.Parameters.AddWithValue("id", user_id);


                using (SqlDataReader reader = commander.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new UserALL
                        {
                            UserID = (int)reader["UserID"],
                            LastName = (string)reader["LastName"],
                            FirstName = (string)reader["FirstName"],
                            Email = (string)reader["Email"],
                            Rue = reader["Rue"] == DBNull.Value ? string.Empty : (string)reader["Rue"],
                            Numero = reader["Numero"] == DBNull.Value ? string.Empty : (string)reader["Numero"],
                            CodePostal = reader["CodePostal"] == DBNull.Value ? 0 : (int)reader["CodePostal"],
                            Ville = reader["Ville"] == DBNull.Value ? string.Empty : (string)reader["Ville"],
                            Pays = reader["Pays"] == DBNull.Value ? string.Empty : (string)reader["Pays"],
                            Gsm = reader["Gsm"] == DBNull.Value ? string.Empty : (string)reader["Gsm"],
                            Phone = reader["Phone"] == DBNull.Value ? string.Empty : (string)reader["Phone"],
                            TypeUser = reader["TypeUser"] == DBNull.Value ? 0 : (int)reader["TypeUser"]
                        };
                    }
                    else
                    {
                        return new UserALL();
                    }
                }
            }
        }


        public int VerifyEmail(string email)
        {
            using (SqlCommand commander = new SqlCommand("SP_verify_if_exist_user", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;

                commander.Parameters.AddWithValue("Email", email);


                using (SqlDataReader reader = commander.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return (int)reader["UserID"];
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }


        public UserALL Login(UserALL user)
        {
            using (SqlCommand commander = new SqlCommand("SP_login_user", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;

                commander.Parameters.AddWithValue("Email", user.Email);
                commander.Parameters.AddWithValue("Password", user.Password);


                using (SqlDataReader reader = commander.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new UserALL
                        {
                            UserID = (int)reader["UserID"],
                            LastName = (string)reader["LastName"],
                            FirstName = (string)reader["FirstName"],
                            Email = (string)reader["Email"],
                        };
                    }
                    else
                    {
                        return new UserALL();
                    }
                }


            }
        }



        public void Create()
        {
        }

        public void Create(UserALL user)
        {
            using (SqlCommand commander = new SqlCommand("SP_create_user", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;

                commander.Parameters.AddWithValue("LastName", user.LastName);
                commander.Parameters.AddWithValue("FirstName", user.FirstName);
                commander.Parameters.AddWithValue("Password", user.Password);
                commander.Parameters.AddWithValue("Email", user.Email);

                commander.ExecuteNonQuery();
            }
        }


        public void DesactivateUser(int user_id)
        {
            using (SqlCommand commander = new SqlCommand("SP_desactivate_user", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;

                commander.Parameters.AddWithValue("UserID", user_id);

                commander.ExecuteNonQuery();
            }
        }

        public void ActivateUser(int user_id)
        {
            using (SqlCommand commander = new SqlCommand("SP_activate_user", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;

                commander.Parameters.AddWithValue("UserID", user_id);

                commander.ExecuteNonQuery();
            }
        }

        public void ChangePassword(int user_id, string password_decrypt)
        {
            using (SqlCommand commander = new SqlCommand("SP_change_password", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;

                commander.Parameters.AddWithValue("UserID", user_id);
                commander.Parameters.AddWithValue("Password", password_decrypt);

                commander.ExecuteNonQuery();
            }
        }

        public void Update(UserInfos user)
        {
            using (SqlCommand commander = new SqlCommand("SP_Update_UserInfos", connection))
            {
                commander.CommandType = CommandType.StoredProcedure;

                commander.Parameters.AddWithValue("UserID", user.UserID);
                commander.Parameters.AddWithValue("LastName", user.LastName);
                commander.Parameters.AddWithValue("FirstName", user.FirstName);
                commander.Parameters.AddWithValue("Email", user.Email);
                commander.Parameters.AddWithValue("Rue", user.Rue);
                commander.Parameters.AddWithValue("Numero", user.Numero);
                commander.Parameters.AddWithValue("CodePostal", user.CodePostal);
                commander.Parameters.AddWithValue("Ville", user.Ville);
                commander.Parameters.AddWithValue("Pays", user.Pays);
                commander.Parameters.AddWithValue("Gsm", user.Gsm);
                commander.Parameters.AddWithValue("Phone", user.Phone);

                commander.ExecuteNonQuery();
                
            }
        }

        public UserALL GetBy(string row, string value)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(UserALL t)
        {
            throw new NotImplementedException();
        }
    }
}
