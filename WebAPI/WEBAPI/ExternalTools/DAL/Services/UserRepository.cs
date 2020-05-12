using DAL.IRepositories;
using DAL.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Services
{
    public class UserRepository : IRepository<User>, IUser
    {
        string connString = null;
        private SqlConnection connection;
        public UserRepository()
        {
            connString = @"Data Source=DESKTOP-D0PIH1A\EVENGYL_SQL_SERV;Initial Catalog=Demo_todo_mvvm_wpf;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            connection = new SqlConnection(connString);
            connection.Open();

        }


        public List<User> GetAll()
        {
            List<User> ListUser = new List<User>();

            using (SqlCommand commander = connection.CreateCommand())
            {
                commander.CommandText = "SELECT * FROM [UserInfos]";

                using (SqlDataReader reader = commander.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListUser.Add(new User
                        {
                            UserID = (int)reader["UserID"],
                            LastName = (string)reader["LastName"],
                            FirstName = (string)reader["FirstName"],
                            Email = (string)reader["Email"],
                            AddressUser = new AddressUser
                                {
                                    Rue = (string)reader["Rue"],
                                    Numero = (string)reader["Numero"],
                                    CodePostal = (int)reader["CodePostal"],
                                    Ville = (string)reader["Ville"],
                                    Pays = (string)reader["Pays"]
                                },
                            ComplementUser = new ComplementUser
                                {
                                    Gsm = (string)reader["Gsm"],
                                    Phone = (string)reader["Phone"],
                                    Benefice = (int)reader["Benefice"],
                                    TotalPrice_InLocate = (int)reader["TotalPrice_InLocate"],
                                    TotalPrice_InAttemps = (int)reader["TotalPrice_InAttemps"]
                                }
                        });
                    }
                    return ListUser;
                }
            }
        }
        public User Get(int user_id)
        {
            using (SqlCommand commander = connection.CreateCommand())
            {
                commander.CommandText = "SELECT * FROM [UserInfos] WHERE UserID = @id";
                commander.Parameters.AddWithValue("id", user_id);


                using (SqlDataReader reader = commander.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            UserID = (int)reader["UserID"],
                            LastName = (string)reader["LastName"],
                            FirstName = (string)reader["FirstName"],
                            Email = (string)reader["Email"],
                            AddressUser = new AddressUser
                            {
                                Rue = (string)reader["Rue"],
                                Numero = (string)reader["Numero"],
                                CodePostal = (int)reader["CodePostal"],
                                Ville = (string)reader["Ville"],
                                Pays = (string)reader["Pays"]
                            },
                            ComplementUser = new ComplementUser
                            {
                                Gsm = (string)reader["Gsm"],
                                Phone = (string)reader["Phone"],
                                Benefice = (int)reader["Benefice"],
                                TotalPrice_InLocate = (int)reader["TotalPrice_InLocate"],
                                TotalPrice_InAttemps = (int)reader["TotalPrice_InAttemps"]
                            }
                        };
                    }
                    else
                    {
                        return new User();
                    }
                }
            }
        }


        public User Login(User user)
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
                        return new User
                        {
                            UserID = (int)reader["UserID"],
                            LastName = (string)reader["LastName"],
                            FirstName = (string)reader["FirstName"],
                            Email = (string)reader["Email"],
                            AddressUser = new AddressUser
                            {
                                Rue = (string)reader["Rue"],
                                Numero = (string)reader["Numero"],
                                CodePostal = (int)reader["CodePostal"],
                                Ville = (string)reader["Ville"],
                                Pays = (string)reader["Pays"]
                            },
                            ComplementUser = new ComplementUser
                            {
                                Gsm = (string)reader["Gsm"],
                                Phone = (string)reader["Phone"],
                                Benefice = (int)reader["Benefice"],
                                TotalPrice_InLocate = (int)reader["TotalPrice_InLocate"],
                                TotalPrice_InAttemps = (int)reader["TotalPrice_InAttemps"]
                            }
                        };
                    }
                    else
                    {
                        return new User();
                    }
                }
            }
        }


        


        public void Create(User user)
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

        public void Update(User user)
        {
            using (SqlCommand commander = connection.CreateCommand())
            {
                commander.CommandText = "UPDATE [user] SET login = @Login, password = @Password, name = @Name, lastName = @LastName " +
                                    "WHERE id = @Id";

                commander.Parameters.AddWithValue("LastName", user.LastName);
                commander.Parameters.AddWithValue("FirstName", user.FirstName);
                commander.Parameters.AddWithValue("Email", user.Email);
                commander.Parameters.AddWithValue("Rue", user.AddressUser.Rue);
                commander.Parameters.AddWithValue("Numero", user.AddressUser.Numero);
                commander.Parameters.AddWithValue("CodePostal", user.AddressUser.CodePostal);
                commander.Parameters.AddWithValue("Ville", user.AddressUser.Ville);
                commander.Parameters.AddWithValue("Pays", user.AddressUser.Pays);
                commander.Parameters.AddWithValue("Gsm", user.ComplementUser.Gsm);
                commander.Parameters.AddWithValue("Phone", user.ComplementUser.Phone);


                commander.ExecuteNonQuery();
            }
        }

        public User GetBy(string row, string value)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
