using AppDev2ndCW.Models;
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

        private readonly DataBaseContext dataBaseContext;

        public AdminController(DataBaseContext db)
        {
            dataBaseContext = db;
        }
        //this is the controller metheod for admin home
        //the authorize helps to make sure that only registered users can go into admin dashboard
        [Authorize]
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


        [HttpPost]  
        public async Task<IActionResult> AddUsers(Users users,string fullName, string email, string phone, string jobtitle, string password)
        {
            users.name = fullName;
            users.email = email;
            users.contacts = phone;
            users.role = jobtitle;
            users.password = password;
            try
            {
                dataBaseContext.Users.Add(users);
                await dataBaseContext.SaveChangesAsync();
                return RedirectToAction("Home");
            }
            catch (Exception)
            {
                return null;
            }
        }        

        public IActionResult AddCustomers()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddCustomers(Customers customers, string customerName, string email, string phone, string customerAddress, string jobtitle, DateTime lastDate )
        {
            customers.Customer_Name = customerName;
            customers.Customer_Email = email;
            customers.Customer_Contact = phone;
            customers.Customer_Address = customerAddress;
            customers.Member_Type = jobtitle;
            customers.Last_Purchased_Date = lastDate;
            try
            {
                dataBaseContext.Customers.Add(customers);
                await dataBaseContext.SaveChangesAsync();
                return RedirectToAction("Home");
            }
            catch (Exception)
            {
                return null;
            }
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
