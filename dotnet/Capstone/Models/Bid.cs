﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Bid
    {
        public int Bid_ID { get; set; }
        public int Item_ID { get; set; }
        public int User_ID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Time_Placed { get; set; }
    }
}