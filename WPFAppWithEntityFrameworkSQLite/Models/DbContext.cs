using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WPFAppWithEntityFrameworkSQLite.Models
{
    internal class ProductContext : DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=products.db");
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
