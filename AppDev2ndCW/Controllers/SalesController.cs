﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult List()
        {
            return View();
        }

        public IActionResult SaleItems()
        {
            return View();
        }

        public IActionResult MakeSales()
        {
            return View();
        }
        public IActionResult AddSaleItem()
        {
            return View();
        }

        public IActionResult GenerateBill()
        {
            return View();
        }
    }
}
