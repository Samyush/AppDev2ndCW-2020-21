using AppDev2ndCW.Models;
using AppDev2ndCW.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppDev2ndCW.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataBaseContext dataBaseContext;
        private readonly UserService _userService;

        public HomeController(DataBaseContext db, UserService userService)
        {
            dataBaseContext = db;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //need to remove register from home
        public IActionResult Register(Users users)
        {
            /*users.contacts = "9860810828";
            users.email = "samyush@admin.com";
            users.id = "2";
            users.name = "admin";
            dataBaseContext.Users.Add(users);
            dataBaseContext.SaveChanges();*/
            return View();
        }

       [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
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

        [HttpPost]
        public async Task<IActionResult> Login(string email, string contact, string ReturnUrl)
        {
            //login functionality
            ViewData["ReturnUrl"] = ReturnUrl;

            if (_userService.TryValidateUser(email,contact, out List<Claim> claims))
            {
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(claimsPrincipal);
                if (ReturnUrl != null)
                {
                    return Redirect(ReturnUrl);
                }
                else { return Redirect("~/Admin/Home"); }
            }
            else
            {
                TempData["Error"] = "Invalid username or password";
                return Redirect("~/Home/Login");
            }
            
          
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("Index");
        }
    }
}
