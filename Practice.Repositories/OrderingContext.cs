using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Practice.Models;

namespace Practice.Repositories
{
    public sealed class OrderingContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        private OrderingContext()
        {
        }

        public OrderingContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUser>().Property(i => i.Id).HasMaxLength(40);
            builder.Entity<IdentityRole>().Property(i => i.Id).HasMaxLength(40);
            
            base.OnModelCreating(builder);
        }
    }
}