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

        public IActionResult BooksInventory(bool Issuccess = false, bool Isdelete = false)
        {
            ViewBag.issuccess = Issuccess;
            ViewBag.isdelete = Isdelete;
            /*BookInventory bki */
            ViewBag.bookList = dataBaseContext.BookInventory.ToArray();

            var bookList = dataBaseContext.BookInventory.ToArray();
            
            return View(bookList);
        }

        public IActionResult BookInventorySearch(int book_id, string button)
        {
            var bookList = dataBaseContext.BookInventory.Where(x => x.Id == book_id).ToArray();
            var book_data = dataBaseContext.BookInventory.ToArray();
            string buttonValue="";
            if (button == "availability")
            { buttonValue = button;
                ViewBag.bookList = bookList;
            }
            else if (button == "stock")
            { buttonValue = "stock";
                ViewBag.bookList = bookList;
            }
            else if (button == "sortQuantity")
            { buttonValue = "sortQuantity";
                var dateSort = book_data.OrderByDescending(x => x.Stock_Quantity).ToArray();
                ViewBag.bookList = dateSort;
            }
            ViewBag.buttonvalue = buttonValue;
            return View();
        }
       


        //this section for adding category

        public IActionResult Category(bool Issuccess = false, bool Isdeletecat = false)
        {
            ViewBag.issuccess = Issuccess;
            ViewBag.isdeletecat = Isdeletecat;
            var categoryList = dataBaseContext.BookCategories.ToArray();
            return View(categoryList);
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
                return RedirectToAction("Category", new { Issuccess = true });
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IActionResult DeleteCategory(int id)
        {
            var category_data = dataBaseContext.BookCategories.Where(x => x.Id == id).First();
            dataBaseContext.BookCategories.Remove(category_data);
            dataBaseContext.SaveChanges();
            return RedirectToAction("Category", new { Isdeletecat = true});
        }

        public async Task<IActionResult> EditCategory(BookCategories categoriesIs, string catName)
        {
            categoriesIs.Category = catName;
            try
            {
                dataBaseContext.BookCategories.Update(categoriesIs);
                await dataBaseContext.SaveChangesAsync();
                return RedirectToAction("~/Books/Category");
            }
            catch (Exception)
            {
                return null;
            }
        }

        //this section for adding book
        public IActionResult AddBook(bool Issuccess = false)
        {
            ViewBag.issuccess = Issuccess;
            /*BookInventory bki */
            ViewBag.categoryList = dataBaseContext.BookCategories.ToArray();
            ViewBag.authorList = dataBaseContext.BookAuthors.ToArray();
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookInventory books, string bookName, string description,int quantity, int rate, int author, int category)
        {   
            books.Book_name = bookName;
            books.Description = description;
            books.Stock_Quantity = quantity;
            books.Price = rate;
            books.Author_Id = author;
            books.Category_Id = category;
            books.Stocked_Date = DateTime.Now;
            try
            {
                dataBaseContext.BookInventory.Add(books);
                await dataBaseContext.SaveChangesAsync();
                return RedirectToAction("BooksInventory", new { Issuccess = true });
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IActionResult DeleteBooksInventory(int id)
        {
            var books_data = dataBaseContext.BookInventory.Where(x => x.Id == id).First();
            dataBaseContext.BookInventory.Remove(books_data);
            dataBaseContext.SaveChanges();
            return RedirectToAction("BooksInventory", new { Isdelete = true });
        }

        public async Task<IActionResult> EditBooks(BookInventory books, string bookName, string description, int quantity, int rate, int author, int category, DateTime lastStockedDate, DateTime lastSalesDate)
        {
            
            books.Book_name = bookName;
            books.Description = description;
            books.Stock_Quantity = quantity;
            books.Price = rate;
            books.Author_Id = author;
            books.Category_Id = category;
            books.Stocked_Date = lastStockedDate;
            books.Sales_Date = lastSalesDate;
            try
            {
                dataBaseContext.BookInventory.Update(books);
                await dataBaseContext.SaveChangesAsync();
                return RedirectToAction("BooksInventory");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IActionResult UpdateBooks(int id)
        {
            var category= dataBaseContext.BookCategories.ToArray(); 
            var author= dataBaseContext.BookAuthors.ToArray();
            var books = dataBaseContext.BookInventory.ToArray();
            /*var books_data = dataBaseContext.BookInventory.Where(x => x.Id == id).First();*/
            var book_data = from c in category
                            join b in books on c.Id equals b.Category_Id into table1
                            from b in table1.ToArray().Where(x => x.Id == id).ToArray()
                            join a in author on b.Author_Id equals a.Id into table2
                            from a in table2.ToArray()
         
                            select new BookAuthorCategoryModel { books = b, categories = c, author = a };
            ViewBag.categoryList = category;
            ViewBag.authorList = author;
            ViewBag.books_data = book_data.First();
            return View();
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

        public IActionResult Authors(bool Issuccess = false, bool Isdeleteaut = false)
        {
            ViewBag.issuccess = Issuccess;
            ViewBag.isdeleteaut = Isdeleteaut;
            var authorList = dataBaseContext.BookAuthors.ToArray();
            return View(authorList);
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
                return RedirectToAction("Authors", new { Issuccess = true });
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IActionResult DeleteAuthors(int id)
        {
            var author_data = dataBaseContext.BookAuthors.Where(x => x.Id == id).First();
            dataBaseContext.BookAuthors.Remove(author_data);
            dataBaseContext.SaveChanges();
            return RedirectToAction("Authors", new { Isdeleteaut = true });
        }

/*        public async Task<IActionResult> EditAuthors(BookAuthor authorIs, string authorName)
        {
            authorIs.Author = authorName;

            try
            {
                dataBaseContext.BookAuthors.Update(authorIs);
                await dataBaseContext.SaveChangesAsync();
                return RedirectToAction("BooksInventory");
            }
            catch (Exception)
            {
                return null;
            }
        }*/
    }
}
