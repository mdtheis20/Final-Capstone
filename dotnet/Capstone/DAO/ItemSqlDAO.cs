using Capstone.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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

                    SqlCommand cmd = new SqlCommand("Select * From Item; " +
                                                     "Select * From item_category IC " +
                                                     "JOIN Category C on IC.category_id = c.category_id", conn);
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
            item.Title = Convert.ToString(rdr["Title"]);
            item.Pic = Convert.ToString(rdr["pic"]);
            item.Starting_Bid = Convert.ToDecimal(rdr["starting_bid"]);
            item.Categories = new List<string>();
            // item.Category.Add(Convert.ToString(rdr["name"]));
            // TODO: rename category name on database

            return item;
        }
    }
}