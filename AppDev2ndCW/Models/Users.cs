using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Models
{
    public class Users
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string contacts { get; set; }

    }
}
