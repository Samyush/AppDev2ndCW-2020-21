using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Models
{
    public class SaleItems
    {
        public long Id { get; set; }
        public long Sale_Id { get; set; }
        public long Book_Id { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }

    }
}
