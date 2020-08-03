using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Item
    {
        public int Item_ID { get; set; }
        public int Auction_ID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Pic { get; set; } // Unsure of picture prop
        public decimal Starting_Bid = 1M; // Unsure of how to set
    }
}
