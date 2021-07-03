using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzaWebAppTest.Models;

namespace PizzaWebAppTest.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ContactDetails> ContactDetailsList { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product>().ToTable("Product");
            builder.Entity<Order>().ToTable("Order");
            builder.Entity<ContactDetails>().ToTable("ContactDetails");
            builder.Entity<OrderProduct>().ToTable("OrderProduct");
        }
    }
}
