using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;
using Capstone.Security;
using System.Collections.Generic;

namespace Capstone.Controllers
{
    [Route("")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemDAO dao;

        public ItemController(IItemDAO itemDAO)
        {
            this.dao = itemDAO;
        }

        [HttpGet("Auction")]

        public IActionResult GetAllItemsForDisplay()
        {
            List<Item> itemList = dao.GetAllItems();
            return Ok(itemList);
        }
  
    }
}
