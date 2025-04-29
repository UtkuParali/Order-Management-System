using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Models;
using System.Collections.Generic;

namespace OrderManagementSystem.Data
{
    public class OrderManagementSystemDbContext : DbContext
    {
        public OrderManagementSystemDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Product> Products => Set<Product>();
    }
}
