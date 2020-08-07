using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Capstone.Controllers
{
    [Route("")]
    [ApiController]       
    public class ItemController : SilentAuctionController
    {
        //private readonly UserManager<User> _userManager;

        //public ItemController(UserManager<User> userManager)
        //{
        //    _userManager = userManager;
        //}
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
           var UserName = HttpContext.User.Identity.Name;
            return Ok(UserName);
        }

        private readonly IItemDAO itemDao;
        private readonly IBidDAO bidDao;
        public ItemController(IItemDAO itemDAO, IBidDAO bidDAO)
        {
            this.itemDao = itemDAO;
            this.bidDao = bidDAO;
        }

        //TODO: Should be '/items' GET 
        [HttpGet("/items")] 
        public IActionResult GetAllItemsForDisplay()
        {
            List<Item> itemList = itemDao.GetAllItems();
            return Ok(itemList);
        } 
        

        // Might want endpoint to add an item
        // POST '/items'
        
        // Might want endpoint to update existing item
        // PUT '/items/{id}

        // Might want endpoint that gets one item
        // GET '/items/{id}

        // Might want endpoint that returns all bids for an item
        // GET '/items/{id}/bids

        // Add new bid
        // POST '/items/{id}/bids
        [Authorize]
        [HttpPost("/items/{itemID}/bids")]
        public ActionResult<Bid> AddNewBid(int itemID, Bid bid)
        {

            decimal amountToCheck = bidDao.GetHighestBidAmountForItem(itemID) + 1m;
            if (bid.Amount >= amountToCheck )
            {
                bid.User_ID = int.Parse(UserId);
                ReturnBid returnedBid = bidDao.AddBid(bid);
                returnedBid.User_Name = Username;
                return Created("", returnedBid);
            }
          else
            {
                return BadRequest();
            }

            // Error check that item_id inside the bid object matches url item_id
            // User id will be pulled by authorized logged in user, not userid from json  
        }
    }
}