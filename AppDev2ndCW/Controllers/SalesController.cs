using AppDev2ndCW.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Controllers
{
    public class SalesController : Controller
    {
        private readonly DataBaseContext databaseContext;

        public SalesController(DataBaseContext db)
        {
            databaseContext = db;
        }
        public IActionResult List()
        {
            var saleList = databaseContext.Sales.ToArray();
            return View(saleList);
        }

        public IActionResult SaleItems()
        {
            return View();
        }

        public IActionResult MakeSales()
        {
            return View();
        }
        public async Task<IActionResult> AddSale(Sales sale, DateTime sale_date, int customer_id, int sale_total)
        {
            sale.Sale_Date = sale_date;
            sale.Customer_Id = customer_id;
            sale.Sale_Total = sale_total;
            try
            {
                databaseContext.Sales.Add(sale);
                await databaseContext.SaveChangesAsync();
                return Redirect("Home");
            }
            catch (Exception)
            {
                return null;
            }
        }
        public IActionResult AddSaleItem()
        {
            return View();
        }
        public async Task<IActionResult> AddSaleItem(SaleItems saleItems, int sale_id, int book_id, int quantity, int total)
        {
            saleItems.Sale_Id = sale_id;
            saleItems.Book_Id = book_id;
            saleItems.Quantity = quantity;
            saleItems.Total = total;
            try
            {
                databaseContext.SaleItems.Add(saleItems);
                await databaseContext.SaveChangesAsync();
                return Redirect("Home");
            }
            catch (Exception)
            {
                return null;
            }
        }
        public IActionResult GenerateBill()
        {
            return View();
        }
    }
}
