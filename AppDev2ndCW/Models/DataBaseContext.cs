using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AppDev2ndCW.Models
{
    public class DataBaseContext : DbContext
    {
        // as per the entity framework this code insures if the database had been created or not, plus if not created it creates automatically
        // and DB context has also been implemented in sartup.cs
        // all public DBSet are for creating tables in the database
        public DbSet<Users> Users { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookCategories> BookCategories { get; set; }
        public DbSet<BookInventory> BookInventory { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<SaleItems> SaleItems { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
   
}

