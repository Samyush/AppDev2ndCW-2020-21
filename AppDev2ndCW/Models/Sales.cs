using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Models
{
    public class Sales
    {
        [Key]
        public long Id { get; set; }
        public DateTime Sale_Date { get; set; }
        public long Customer_Id { get; set; }
        public int Sale_Total { get; set; }

        [ForeignKey("Customer_Id")]
        public Customers Customers { get; set; }
        public ICollection<SaleItems> SaleItems { get; set; }
    }
}
