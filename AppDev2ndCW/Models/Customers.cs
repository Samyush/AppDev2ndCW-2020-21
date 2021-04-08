using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Models
{
    public class Customers
    {
        [Key]
        public long Id { get; set; }
        public string Customer_Name { get; set; }
        public string Customer_Email { get; set; }
        public string Customer_Address { get; set; }
        public string Customer_Contact { get; set; }
        public string Member_Type { get; set; }
        public DateTime Last_Purchased_Date { get; set; }
        public ICollection<Sales> Sales { get; set; }
    }
}
