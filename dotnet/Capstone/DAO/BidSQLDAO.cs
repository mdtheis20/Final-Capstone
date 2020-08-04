using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class BidSqlDAO : IBidDAO
    {
        private readonly string connectionString;

        public BidSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Bid> GetBidsByItem(int id)
        {
            List<Bid> bidsByIDs = new List<Bid>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select * from bid join item on item.item_id = bid.item_id where item.item_id = @item_id", conn);
                    cmd.Parameters.AddWithValue("@item_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Bid bid = RowToObject(reader);
                        bidsByIDs.Add(bid);
                    }
                    return bidsByIDs;
                }              
            }
            catch(SqlException)
            {
                throw;
            }
        }
        private static Bid RowToObject(SqlDataReader rdr)
        {
            Bid bid = new Bid();
            bid.Amount = Convert.ToDecimal(rdr["amount"]);
            bid.Bid_ID = Convert.ToInt32(rdr["bid_id"]);
            bid.Item_ID = Convert.ToInt32(rdr["Item_id"]);
            bid.Time_Placed = Convert.ToDateTime(rdr["time_placed"]);
            bid.User_ID = Convert.ToInt32(rdr["user_id"]);
            return bid;
        }
    }
}
