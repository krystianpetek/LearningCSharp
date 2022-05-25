using Microsoft.EntityFrameworkCore;

namespace LAB2_WITHOUTMVC.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Kajak",
                    Description = "Łódka przeznaczona dla jednej osoby",
                    Category = "Sporty wodne",
                    Price = 275
                },
                new Product
                {
                    Id = 2,
                    Name = "Kamizelka ratunkowa",
                    Description = "Chroni i dodaje uroku",
                    Category = "Sporty wodne",
                    Price = 48.95m
                },
                new Product
                {
                    Id = 3,
                    Name = "Piłka",
                    Description = "Zatwierdzone przez FIFA rozmiar i waga",
                    Category = "Piłka nożna",
                    Price = 19.50m
                });
        }
    }
}
