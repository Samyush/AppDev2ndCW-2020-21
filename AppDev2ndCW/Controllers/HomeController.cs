using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //need to remove register from home
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            /*if (Login == admin)
            {
                return RedirectToAction("Home", "Admin");
            }
            else
            {
                return RedirectToAction("Home", "Users");
            }*/
            return View();
        }
    }
}
