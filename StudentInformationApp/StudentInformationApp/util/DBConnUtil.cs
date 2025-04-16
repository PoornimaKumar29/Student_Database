using System;
using Microsoft.Data.SqlClient;

namespace StudentInformationSystem
{
    public static class DBConnUtil
    {
        // Replace with your actual SQL Server details
        private static readonly string connectionString = "Data Source=POORNIMA\\SQLSERVER2022;Initial Catalog=SISDB;Integrated Security=True;";

        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while creating DB connection: " + ex.Message);
            }
        }
    }
}
