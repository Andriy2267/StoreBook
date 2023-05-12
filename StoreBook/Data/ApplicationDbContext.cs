using Microsoft.EntityFrameworkCore;
using StoreBook.Models;

namespace StoreBook.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Kefir", DisplayOrder = 1 },
                new Category { Id = 2, Name = "WiFi", DisplayOrder = 2},
                new Category { Id = 3, Name = "Action", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Lords of the rings",
                    Description = "Fantasy book for children and adult",
                    ISBN = "WWW999011YY",
                    Author = "Chopek Andriy",
                    Price = 3.0d,
                    ListPrice = 34.6d,
                    Price50 = 110.6d,
                    Price100 = 180d
                },
                new Product
                {
                    Id = 2,
                    Title = "Lords of the rings",
                    Description = "Fantasy book for children and adult",
                    ISBN = "WWW999011YY",
                    Author = "Chopek Andriy",
                    Price = 3.0d,
                    ListPrice = 34.6d,
                    Price50 = 110.6d,
                    Price100 = 180d
                },
                new Product
                {
                    Id = 3,
                    Title = "Lords of the rings",
                    Description = "Fantasy book for children and adult",
                    ISBN = "WWW999011YY",
                    Author = "Chopek Andriy",
                    Price = 3.0d,
                    ListPrice = 34.6d,
                    Price50 = 110.6d,
                    Price100 = 180d
                }
                );
        }
    }
}
