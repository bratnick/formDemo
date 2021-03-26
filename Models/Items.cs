using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoform3.Models
{
    public class Items
    {
        public IEnumerable<Item> items { get; set; }
        public Item getElementById(int id)
        {
            return items.FirstOrDefault(p => p.itemId == id);
        }
    }
}
