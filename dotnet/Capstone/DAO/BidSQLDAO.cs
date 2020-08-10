using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;


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
            catch (SqlException)
            {
                throw;
            }
        }
        // TODO: Fix this!
        //public int UserId
        //{
        //    get
        //    {
        //        int userId = 0;
        //        Claim subjectClaim = User?.Claims?.Where(cl => cl.Type == "sub").FirstOrDefault();
        //        if (subjectClaim != null)
        //        {
        //            int.TryParse(subjectClaim.Value, out userId);
        //        }
        //        return userId;
        //    }
        //}

        // Alternate non-working method
        //private int userId
        //{
        //    get
        //    {
        //        foreach (Claim claim in )
        //        {
        //            if (claim.Type == "sub")
        //            {
        //                return Convert.ToInt32(claim.Value);
        //            }
        //        }
        //        return 0;
        //    }
        //}
        public ReturnBid AddBid(Bid bid) 
        {
            
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    string timeStamp = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                    SqlCommand cmd = new SqlCommand($"INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (@item_id, @user_id, @bid_amount, @now); Select @@IDENTITY;", conn);
                    cmd.Parameters.AddWithValue("@item_id", bid.Item_ID);
                    cmd.Parameters.AddWithValue("@user_id", bid.User_ID);  
                    cmd.Parameters.AddWithValue("@bid_amount", bid.Amount);
                    cmd.Parameters.AddWithValue("@now", timeStamp);
                    int newID = Convert.ToInt32(cmd.ExecuteScalar());

                    ReturnBid returnedBid = new ReturnBid();
                    returnedBid.Amount = bid.Amount;
                    returnedBid.Item_ID = bid.Item_ID;
                    returnedBid.Time_Placed = timeStamp;
                    returnedBid.Bid_ID = newID;
                    
                    return returnedBid; 
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
        public decimal GetHighestBidAmountForItem(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select MAX(amount) from bid where item_id = @item_id", conn);
                    cmd.Parameters.AddWithValue("@item_id", id);
                    decimal topAmount = Convert.ToDecimal(cmd.ExecuteScalar());

                    return topAmount;
                }
            }
            catch (SqlException)
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

        //ReturnBid IBidDAO.AddBid(Bid bid, string userId)
        //{
        //    throw new NotImplementedException();
        //}

        //Bid IBidDAO.AddBid(Bid bid)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
