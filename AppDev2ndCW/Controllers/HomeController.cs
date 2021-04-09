using AppDev2ndCW.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Controllers
{
    public class HomeController : Controller
    {

        private readonly DataBaseContext dataBaseContext;

        public HomeController(DataBaseContext db)
        {
            dataBaseContext = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        //need to remove register from home
        public IActionResult Register(Users users)
        {
            users.contacts = "sd";
            users.email = "sd";
            users.id = "1";
            users.name = "sa";
            dataBaseContext.Users.Add(users);
            dataBaseContext.SaveChanges();
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
