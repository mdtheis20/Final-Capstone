using Capstone.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;

namespace Capstone.DAO
{
    public class ItemSqlDAO : IItemDAO
    {
        private readonly string connectionString;

        public ItemSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public List<Item> GetAllItems()
        {
            List<Item> returnItems = new List<Item>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Select * From Item order by title; " +
                                                     "Select * From item_category IC " +
                                                     "JOIN Category C on IC.category_id = c.category_id; " +
                                                     "SELECT TOP(10) * From bid " +
                                                     "JOIN item on bid.item_id = item.item_id " +
                                                     "JOIN users on users.user_id = bid.user_id", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Item item = RowToObject(reader);
                        returnItems.Add(item);
                    }
                    reader.NextResult();
                    while (reader.Read())
                    {
                        int item_ID = Convert.ToInt32(reader["item_id"]);
                        string name = Convert.ToString(reader["name"]);
                        // TODO: find the item with the id of 'item_id'
                        Item foundItem = returnItems.Find(item => item.Item_ID == item_ID);
                        // TODO: add name to list of categories
                        foundItem.Categories.Add(name);
                    }
                    reader.NextResult();
                    while (reader.Read())
                    {
                        ReturnBid bid = BidRowToObject(reader);
                        int item_ID = Convert.ToInt32(reader["item_ID"]);
                        // Attach bids to each item as list
                        Item foundBid = returnItems.Find(item => item.Item_ID == item_ID);
                        foundBid.Bids.Add(bid);
                    }
                    return returnItems;
                }
            }
            catch (SqlException)
            {
                throw;
            }
        }
        private static Item RowToObject(SqlDataReader rdr) 
        {
            Item item = new Item();
            item.Item_ID = Convert.ToInt32(rdr["item_id"]);
            item.Auction_ID = Convert.ToInt32(rdr["auction_id"]);
            item.Subtitle = Convert.ToString(rdr["subtitle"]);
            item.Title = Convert.ToString(rdr["Title"]);
            item.Pic = Convert.ToString(rdr["pic"]);
            item.Starting_Bid = Convert.ToDecimal(rdr["starting_bid"]);
            item.Categories = new List<string>();
            item.Bids = new List<ReturnBid>();
            // item.Category.Add(Convert.ToString(rdr["name"]));
            // TODO: rename category name on database
            return item;
        }
        private static ReturnBid BidRowToObject(SqlDataReader rdr)
        {
            ReturnBid bid = new ReturnBid();
            bid.Bid_ID = Convert.ToInt32(rdr["bid_id"]);
            bid.Item_ID = Convert.ToInt32(rdr["item_ID"]);
            bid.Amount = Convert.ToInt32(rdr["amount"]);
            bid.User_Name = Convert.ToString(rdr["username"]);
            return bid;
        }
    }
}