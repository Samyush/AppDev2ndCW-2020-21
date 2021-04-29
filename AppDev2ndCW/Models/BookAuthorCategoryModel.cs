using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Models
{
    public class BookAuthorCategoryModel
    {
        public BookInventory books { get; set; }
        public BookCategories categories { get; set; }
        public BookAuthor author { get; set; }
    }
}
