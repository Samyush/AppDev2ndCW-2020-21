using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Models
{
    public class SaleItems
    {
        [Key]
        public long Id { get; set; }
        public long Sale_Id { get; set; }
        public long Book_Id { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }

        [ForeignKey("Sale_Id")]
        public Sales Sales { get; set; }

        [ForeignKey("Book_Id")]
        public BookInventory BookInventory { get; set; }
        
        
    }
}
