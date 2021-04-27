using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Models
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string contacts { get; set; }
        public string role { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 5,
            ErrorMessage = "Title must be between 5 and 100 characters long")]
        public string password { get; set; }
    }
}
