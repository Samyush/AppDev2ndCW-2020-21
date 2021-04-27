using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }


        public IActionResult Login()
        {

            //the below method directs to Admin Controller Class and Home Method
            return RedirectToAction("Home", "Admin");

            //it ridirects to route
            /*return RedirectToRoute("admin/home");*/

            //it ridirects to direct view
            /*return View("~/Views/Admin/home.cshtml");*/
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        public IActionResult InactiveItems()
        {
            return View();
        }

        public IActionResult InactiveCustomers()
        {
            return View();
        }

        public IActionResult OutOfStock()
        {
            return View();
        }

        public IActionResult LongStocked()
        {
            return View();
        }
    }
}
