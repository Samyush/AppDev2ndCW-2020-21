using AppDev2ndCW.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Controllers
{

    public class CustomerController : Controller
    {
        private readonly DataBaseContext dataBaseContext;
        /*
        [Route("")]
        public IActionResult Index()
        {
            return new ContentResult { Content = "Try"};
        }*/

        public CustomerController(DataBaseContext db)
        {
            dataBaseContext = db;
        }
        public IActionResult PurchaseHistory()
        {
            return View();  
        }

        public IActionResult Home()
        {
            return View();
        }

        /*[Route("login/{email:string}/{password:string}")]*/
        [Route("login/{email:int}/{password:int}")]
        public IActionResult Login(int email, int password)
        {
            return new ContentResult { Content = string.Format("Email: {0}; Passsword: {1};", email, password) };
        }

        public IActionResult Profile(int id)
        {
            ViewBag.customer_data = dataBaseContext.Customers.Where(x => x.Id == id).First();
            DateTime currentDate = DateTime.Now.Date;
            DateTime lastDate = currentDate.Subtract(new TimeSpan(31, 0, 0, 0, 0));
            var userHistory = dataBaseContext.Sales.Where(x => x.Customer_Id == id).Where(a => a.Sale_Date >= lastDate).ToArray();
            ViewBag.history = userHistory;
            return View();
        }
    }
}
