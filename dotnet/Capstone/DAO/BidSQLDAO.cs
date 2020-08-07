﻿using Capstone.Models;
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
        public void AddBid(Bid bid, string userId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"INSERT INTO bid (item_id, user_id, amount, time_placed) VALUES (@item_id, @user_id, @bid_amount, @now); Select @@IDENTITY;", conn);
                    cmd.Parameters.AddWithValue("@item_id", bid.Item_ID);
                    cmd.Parameters.AddWithValue("@user_id", int.Parse(userId));  
                    cmd.Parameters.AddWithValue("@bid_amount", bid.Amount);
                    cmd.Parameters.AddWithValue("@now", DateTime.Now);
                    int newID = Convert.ToInt32(cmd.ExecuteScalar());

                    bid.Bid_ID = newID;

                    return;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
        public decimal GetHighestBidAmountForItem(int id)
        {
            decimal topAmount = 0;

            Bid highestBid = new Bid();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select MAX(amount) from bid where item_id = @item_id", conn);
                    cmd.Parameters.AddWithValue("@item_id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        highestBid = RowToObject(reader);
                        topAmount = highestBid.Amount;
                    }
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

        //Bid IBidDAO.AddBid(Bid bid)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
