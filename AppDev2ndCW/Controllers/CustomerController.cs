using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Controllers
{
    [Route("customer")]
    public class CustomerController : Controller
    {

        [Route("")]
        public IActionResult Index()
        {
            return new ContentResult { Content = "Try"};
        }

        public IActionResult AddCustomer()
        {   
            return View();
        }
        public IActionResult DeleteCustomer()
        {
            return View();
        }
        public IActionResult ViewCustomerData()
        {
            return View();  
        }

        /*[Route("login/{email:string}/{password:string}")]*/
        [Route("login/{email:int}/{password:int}")]
        public IActionResult Login(int email, int password)
        {
            return new ContentResult { Content = string.Format("Email: {0}; Passsword: {1};", email, password) };
        }

        [Route("profile")]
        public IActionResult CustomerProfile()
        {
            return View();
        }
    }
}
