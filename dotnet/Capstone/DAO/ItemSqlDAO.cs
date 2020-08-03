using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.Security;
using Capstone.Security.Models;

namespace Capstone.DAO
{
    public class ItemSqlDAO : IItemDAO
    {
        private readonly string connectionString;

        public ItemSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public Item GetItemsByCategory(string category)
        {
            List<Item> ReturnList;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && reader.Read())
                    {
                        returnUser = GetUserFromReader(reader);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return ReturnList;
        }
    }
}