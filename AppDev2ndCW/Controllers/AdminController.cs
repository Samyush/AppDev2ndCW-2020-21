using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Users()
        {

            
            return RedirectToAction("Home", "User");
                
        }



        public IActionResult AddUsers() 
        {
            return Home();
        }
        
       public IActionResult DeleteUsers()
        {
            return Home();
        }
    }
}
