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

        public IActionResult Dashboard(bool IsLogin = false )

        {
            if (IsLogin)
            {
                var stock = dataBaseContext.BookInventory.Where(x => x.Stock_Quantity <= 10).ToArray();
                if (stock.Length != 0)
                {
                    ViewBag.stockData = "hasValue";
                    ViewBag.books = stock;
                }
                else 
                {
                    ViewBag.stockData = "null";
                }
            }
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

        public async Task<IActionResult> EditPassword(Users users, string oldPassword, string newPassword)
        {
            var claimsPrinciple = User.Claims;
            var c = claimsPrinciple.Where(a=>a.Type=="id").FirstOrDefault().Value;

            users.name = claimsPrinciple.Where(a=>a.Type=="name").FirstOrDefault().Value;
            users.email = claimsPrinciple.Where(a => a.Type == "email").FirstOrDefault().Value;
            users.contacts = claimsPrinciple.Where(a => a.Type == "contact").FirstOrDefault().Value;
            users.role = claimsPrinciple.Where(a => a.Type == "role").FirstOrDefault().Value;
            var oldpassword = claimsPrinciple.Where(a => a.Type == "password").FirstOrDefault().Value;
            users.password = newPassword;
            if (oldpassword == oldPassword)
            {
                try
                {
                    dataBaseContext.Users.Update(users);
                    await dataBaseContext.SaveChangesAsync();
                    return Redirect("~/Admin/ManageUsers");
                }
                catch
                {
                    return null;
                }
            }
            else 
            {
                return Redirect("~/Admin/ManageUsers");
            }
            
        }
        public IActionResult InactiveItems()
        {
            DateTime currentDate = DateTime.Now.Date;
            DateTime lastDate = currentDate.Subtract(new TimeSpan(31, 0, 0, 0, 0));
            var inactiveItemList = dataBaseContext.BookInventory.Where(x => x.Sales_Date <= lastDate).ToArray();
            return View(inactiveItemList);
        }

        public IActionResult InactiveCustomers()
        {
            DateTime currentDate = DateTime.Now.Date;
            DateTime lastDate = currentDate.Subtract(new TimeSpan(31, 0, 0, 0, 0));
            var inactiveCustomerList = dataBaseContext.Customers.Where(x => x.Last_Purchased_Date <= lastDate).ToArray();
            return View(inactiveCustomerList);
        }

        public IActionResult OutOfStock(string sort)
        {
            /*var stockList = dataBaseContext.BookInventory.ToArray(0);
            return View(stockList);*/
            /*return View();*/
            var bookstockList = dataBaseContext.BookInventory.Where(x => x.Stock_Quantity == 0).ToArray();
            if (sort == "ascending")
            {
                var ascendingSort = bookstockList.OrderBy(x => x.Book_name).ToArray();
                return View(ascendingSort);
            }
            else if (sort == "quantity")
            {
                var quantitySort = bookstockList.OrderBy(x => x.Stock_Quantity).ToArray();
                return View(quantitySort);
            }
            else if (sort == "stockDate")
            {
                var dateSort = bookstockList.OrderByDescending(x => x.Stocked_Date).ToArray();
                return View(dateSort);
            }
            else
            {
                return View(bookstockList);
            }
           
            
        }

        public IActionResult LongStocked()
        {
            DateTime currentDate = DateTime.Now.Date;
            DateTime lastDate = currentDate.Subtract(new TimeSpan(31, 0, 0, 0, 0));
            var inactiveItemList = dataBaseContext.BookInventory.Where(x => x.Sales_Date <= lastDate).ToArray();
            //var inactiveItemList = dataBaseContext.BookInventory.Where(x => x.Stocked_Date <= lastDate).ToArray();
            return View(inactiveItemList);
        }

        public IActionResult DeleteAllBooks()
        {
            DateTime currentDate = DateTime.Now.Date;
            DateTime lastDate = currentDate.Subtract(new TimeSpan(31, 0, 0, 0, 0));
            var inactiveItemList = dataBaseContext.BookInventory.Where(x => x.Sales_Date <= lastDate).ToArray();

            foreach (var books in inactiveItemList)
            {
                dataBaseContext.Remove(books);
                dataBaseContext.SaveChanges();
            }
            return Redirect("Dashboard");
        }
    }
}
