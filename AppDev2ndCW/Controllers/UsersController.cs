using AppDev2ndCW.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Controllers
{
    public class UsersController : Controller
    {
        private readonly DataBaseContext dataBaseContext;

        public UsersController(DataBaseContext db)
        {
            dataBaseContext = db;
        }
        public IActionResult Dashboard(bool IsLogin = false)

        {
            ViewBag.isLogin = IsLogin;
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
            DateTime currentDate = DateTime.Now.Date;
            DateTime lastDate = currentDate.Subtract(new TimeSpan(31,0,0,0,0));
            var inactiveItemList = dataBaseContext.BookInventory.Where(x => x.Sales_Date <=lastDate ).ToArray();
            return View(inactiveItemList);
        }

        public IActionResult InactiveCustomers()
        {
            DateTime currentDate = DateTime.Now.Date;
            DateTime lastDate = currentDate.Subtract(new TimeSpan(31, 0, 0, 0, 0));
            var inactiveCustomerList = dataBaseContext.Customers.Where(x => x.Last_Purchased_Date <= lastDate).ToArray();
            return View(inactiveCustomerList);
        }

        public IActionResult OutOfStock()
        {
            /*var stockList = dataBaseContext.BookInventory.ToArray(0);
            return View(stockList);*/
            /*return View();*/
            var bookstockList = dataBaseContext.BookInventory.Where(x => x.Stock_Quantity == 0).ToArray();
            return View(bookstockList);
        }

        public IActionResult LongStocked()
        {
            DateTime currentDate = DateTime.Now.Date;
            DateTime lastDate = currentDate.Subtract(new TimeSpan(31, 0, 0, 0, 0));
            var inactiveItemList = dataBaseContext.BookInventory.Where(x => x.Stocked_Date <= lastDate).ToArray();
            return View(inactiveItemList);
        }
    }
}
