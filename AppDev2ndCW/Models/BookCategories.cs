using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Models
{
    public class BookCategories
    {
        [Key]
        public long Id { get; set; }
        public string Category { get; set; }
        //public ICollection<Customers> Customers { get; set; }
    }
}
