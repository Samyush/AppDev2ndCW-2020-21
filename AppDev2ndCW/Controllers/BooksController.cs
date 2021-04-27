using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 

        public IActionResult BooksInventory()
        {

            /*BookInventory bki */
            return View();
        }

        public IActionResult DeleteBooksInventory()
        {
                
            /*BookInventory bki */
            return View();
        }

        public IActionResult AddBook()
        {
            /*BookInventory bki */
            return View();
        }

        public IActionResult Category()
        {
                
            /*BookInventory bki */
            return View();
        }

        public IActionResult AddAuthor()
        {

            /*BookInventory bki */  
            return View();
        }
    }
}
