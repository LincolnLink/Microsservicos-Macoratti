using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Models;

namespace VShop.ProductApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }  
        
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        //Fluent API

    }
}
