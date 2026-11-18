using CQRSProject_Product.Product;
using Microsoft.EntityFrameworkCore;

namespace CQRSProject_Product.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product.Product> Products => Set<Product.Product>();
        public DbSet<Order> Orders => Set<Order>();
    }
}
