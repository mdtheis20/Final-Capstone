using System;
using System.Collections.Generic;
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


    }
