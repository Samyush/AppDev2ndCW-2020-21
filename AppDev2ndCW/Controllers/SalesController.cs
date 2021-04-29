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

        public IActionResult SaleItems(int id)
        {
            var saleItemList = databaseContext.SaleItems.Where(x => x.Sale_Id == id).ToArray();
            return View(saleItemList);
        }

        public IActionResult MakeSales()
        {
            ViewBag.customerList = databaseContext.Customers.ToArray();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSale(Sales sale,  int customer_id)
        {
            sale.Sale_Date = DateTime.Now;
            sale.Customer_Id = customer_id;
            sale.Sale_Total = 0;
            try
            {
                databaseContext.Sales.Add(sale);
                await databaseContext.SaveChangesAsync();
                var saleData = databaseContext.Sales.ToArray();
                var data = saleData.LastOrDefault();
                return RedirectToAction("AddSaleItem");
            }
            catch (Exception)
            {
                return null;
            }
        }
        public IActionResult AddSaleItem()
        {
            ViewBag.bookList = databaseContext.BookInventory.Where(x=>x.Stock_Quantity>0).ToArray();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSaleItem(SaleItems saleItems, Sales sales,int book_id, int quantity)
        {
            var saleData = databaseContext.Sales.ToArray();
            var data = saleData.LastOrDefault();
            var book_data = databaseContext.BookInventory.Where(x => x.Id == book_id).FirstOrDefault();
            int rate = book_data.Price;
            saleItems.Sale_Id = data.Id;
            saleItems.Book_Id = book_id;
            saleItems.Quantity = quantity;
            saleItems.Total = quantity*rate;

            book_data.Sales_Date = data.Sale_Date;
            book_data.Stock_Quantity = book_data.Stock_Quantity - quantity;
            try
            {
                databaseContext.SaleItems.Add(saleItems);
                databaseContext.BookInventory.Attach(book_data);
                await databaseContext.SaveChangesAsync();
                return RedirectToAction("GenerateBill");
            }
            catch (Exception)
            {
                return null;
            }
        }
        public IActionResult GenerateBill()
        {
            var saleData = databaseContext.Sales.ToArray();
            var data = saleData.LastOrDefault();
            var saleItemData = databaseContext.SaleItems.ToArray();
            var books = databaseContext.BookInventory.ToArray();
            ViewBag.data = data;
            var totalData = from s in saleData
                            join i in saleItemData on s.Id equals i.Sale_Id into table1
                            from i in table1.ToArray().Where(i => i.Sale_Id == data.Id).ToArray()
                            join b in books on i.Book_Id equals b.Id into table2
                            from b in table2.ToArray()
                            select new SaleDataBooksModel { salesData=s, saleItemData=i,books=b};
            int totalPrice=0;
            foreach (var item in totalData)
            {
                totalPrice = totalPrice + item.saleItemData.Total;
            }
            ViewBag.customer_data = databaseContext.Customers.Where(x => x.Id == data.Customer_Id).FirstOrDefault();
            ViewBag.totalSaleData = totalData;
            ViewBag.totalPriceAmount = totalPrice;
            return View();
        }

        
        public async Task<IActionResult> EditSales(Sales sales, int customer_id,DateTime sale_Date,int totalPriceAmount)
        {
            var customer_data = databaseContext.Customers.Where(x => x.Id == customer_id).FirstOrDefault();

            sales.Customer_Id = customer_id;
            sales.Sale_Total = totalPriceAmount;
            sales.Sale_Date = sale_Date;
            customer_data.Last_Purchased_Date = sale_Date;
            
            try
            {
                databaseContext.Sales.Update(sales);
                databaseContext.Customers.Attach(customer_data);
                await databaseContext.SaveChangesAsync();
                return RedirectToAction("List");

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
