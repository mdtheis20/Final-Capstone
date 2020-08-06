using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{
    [Route("")]
    [ApiController]
    [Authorize]
    public class ItemController : ControllerBase
    {
        private readonly IItemDAO itemDao;
        private readonly IBidDAO bidDao;
        public ItemController(IItemDAO itemDAO, IBidDAO bidDAO)
        {
            this.itemDao = itemDAO;
            this.bidDao = bidDAO;
        }

        //TODO: Should be '/items' GET 
        [HttpGet("items")] 
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
        [HttpPost("/items/{itemID}/bids")]
        public IActionResult AddNewBid(int itemID, Bid bid)
        {
            // Error check that item_id inside the bid object matches url item_id
            // User id will be pulled by authorized logged in user, not userid from json            
            bidDao.AddBid(bid);
            return Ok();
        }
    }
}