using Microsoft.EntityFrameworkCore;
using SAOnlineMartMVC.Models;

namespace SAOnlineMartMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Define DbSets for your models
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        // Configure model relationships and database constraints
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Example: Configure OrderId as a unique identifier with a max length if needed
            modelBuilder.Entity<Order>()
                .Property(o => o.OrderId)
                .IsRequired()
                .HasMaxLength(50);


        }
    }
}
