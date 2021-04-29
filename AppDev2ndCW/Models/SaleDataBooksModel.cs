using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Models
{
    public class SaleDataBooksModel
    {
        public Sales salesData { get; set; }
        public SaleItems saleItemData { get; set; }
        public BookInventory books { get; set; }
    }
}
