﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return new ContentResult { Content = "Try"};
        }
    }
}
