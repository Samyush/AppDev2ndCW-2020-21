using AppDev2ndCW.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDev2ndCW.Controllers
{
    public class BooksController : Controller
    {
        private readonly DataBaseContext dataBaseContext;

        public BooksController(DataBaseContext db)
        {
            dataBaseContext = db;
        }
           
        
        //index not in function
       /* public IActionResult Index()
        {
            //pass data

            return View();
        } */

        public IActionResult BooksInventory()
        {

            /*BookInventory bki */
            return View();
        }

        public IActionResult DeleteBooksInventory()
        {
                
            /*BookInventory bki */
            return View();
        }

        //this section for adding category

        public IActionResult Category()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(BookCategories categoriesIs, string catName)
        {
            //categoriesIs.Id = id;
            categoriesIs.Category = catName;

            try
            {
                dataBaseContext.BookCategories.Add(categoriesIs);
                await dataBaseContext.SaveChangesAsync();
                return RedirectToAction("BooksInventory");
            }
            catch (Exception)
            {
                return null;
            }
        }



        //this section for adding book
        public IActionResult AddBook()
        {
            /*BookInventory bki */
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookInventory books, string bookName, int quantity, int rate, int author, int category)
        {   
            books.Book_name = bookName;
            books.Stock_Quantity = quantity;
            books.Price = rate;
            books.Author_Id = author;
            books.Category_Id = category;
            books.Stocked_Date = DateTime.Now;
            try
            {
                dataBaseContext.BookInventory.Add(books);
                await dataBaseContext.SaveChangesAsync();
                return RedirectToAction("BooksInventory");
            }
            catch (Exception)
            {
                return null;
            }
        }

       

        //this section for add author

        public IActionResult AddAuthor(BookAuthor authorIs)
        {
            //authorIs.Id = 1;
            /*authorIs.Author = "ram";
            dataBaseContext.BookAuthors.Add(authorIs);
            dataBaseContext.SaveChanges();*/
            /*BookInventory bki */
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddAuthor(BookAuthor authorIs, string authorName)
        {
            //authorIs.Id = id;
            authorIs.Author = authorName;
            
            try
            {
                dataBaseContext.BookAuthors.Add(authorIs);
                await dataBaseContext.SaveChangesAsync();
                return RedirectToAction("BooksInventory");
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
