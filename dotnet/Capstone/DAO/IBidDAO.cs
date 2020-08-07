using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IBidDAO
    {
        Bid AddBid(Bid bid, string userId);
        List<Bid> GetBidsByItem(int id);
        decimal GetHighestBidAmountForItem(int id);
    }
}
