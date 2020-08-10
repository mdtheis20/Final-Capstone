using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IBidDAO
    {
        ReturnBid AddBid(Bid bid, string userId); //TODO: Need to change return type
        List<Bid> GetBidsByItem(int id);
        decimal GetHighestBidAmountForItem(int id);
    }
}
