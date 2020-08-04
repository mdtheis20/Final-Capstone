using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class BidSQLDAO : IBidDAO
    {
        private readonly string connectionString;

        public BidSQLDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Bid> GetBidsByItem()
        {
            List<Bid> bidsByIDs = new List<Bid>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("	Select * from bid join item on item.item_id = bid.item_id where item.item_id = @item_id", conn);
                }
            }
        }

    }
}
