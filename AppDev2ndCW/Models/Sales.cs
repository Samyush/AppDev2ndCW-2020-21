using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Models
{
    public class Sales
    {
        public long Id { get; set; }
        public DateTime Sale_Date { get; set; }
        public long Customer_Id { get; set; }
        public int Sale_Total { get; set; }
    }
}
