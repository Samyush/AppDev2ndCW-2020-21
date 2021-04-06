using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Models
{
    public class BookInventory
    {
        public long Id { get; set; }
        public string Book_name { get; set; }
        public long Author_Id { get; set; }
        public string Description { get; set; }
        public long Category_Id { get; set; }
        public int Price { get; set; }
        public DateTime Stocked_Date { get; set; }
        public int Stock_Quantity { get; set; }
        public DateTime Sales_Date { get; set; }
    }
}
