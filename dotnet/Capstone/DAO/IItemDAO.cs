using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public interface IItemDAO
    {
        void AddNewItem(Item item);
        List<Item> GetAllItems();
        Item GetSingleItem(int item_Id);
    }
}
