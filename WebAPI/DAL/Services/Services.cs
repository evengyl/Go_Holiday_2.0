using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Services
{
    public class Services
    {
        public SqlConnection connection;
        public string connString;

        public Services()
        {
            connString = @"Data Source=DESKTOP-F5TR94A\SQLEXPRESS;Initial Catalog=GoHoliday;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            connection = new SqlConnection(connString);
            connection.Open();
        }

        
    }
}
