using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Controllers;

namespace Capstone.DAO
{
    public interface IBidDAO 
    {
        ReturnBid AddBid(Bid bid);
        List<Bid> GetBidsByItem(int id);
        decimal GetHighestBidAmountForItem(int id);
    }
}
