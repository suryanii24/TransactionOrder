using Microsoft.EntityFrameworkCore;
using System;
using TransactionOrder.Entities;


namespace TransactionOrder
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Product => Set<Product>();
        public DbSet<Category> Category => Set<Category>();
        public DbSet<Order> Order => Set<Order>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Order>()
                .HasKey(o => o.TransactionId);
            modelBuilder.Entity<OrderDetail>()
                .HasKey(o => o.TransactionDetailId);
            modelBuilder.Entity<Product>()
                .HasKey(o => o.ProductId);
            modelBuilder.Entity<Category>()
                .HasKey(o => o.CategoryId);
        }
        public DbSet<OrderDetail> OrderDetail => Set<OrderDetail>();
        
    }
}
