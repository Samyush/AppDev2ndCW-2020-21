using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Controllers
{
    public class AdminController : Controller
    {

        //this is the controller metheod for admin home
        /*[Authorize]*/
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
            return View();
        }

        public IActionResult AddCustomers()
        {
            return View();
        }

        public IActionResult DeleteUsers()
        {
            return Home();
        }

       /* public IActionResult ()
        {
            return Home();
        }
        public IActionResult DeleteUsers()
        {
            return Home();
        }
        public IActionResult DeleteUsers()
        {
            return Home();
        }*/
    }
}
