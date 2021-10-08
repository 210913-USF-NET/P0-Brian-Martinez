using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public class P1_DBContext : DbContext
    {
        public P1_DBContext() : base() { }
        public P1_DBContext(DbContextOptions options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<StoreFront> StoreFronts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Order> Orders { get; set; }

/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(customer => customer.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<StoreFront>()
                .Property(store => store.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>()
                .Property(product => product.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<LineItem>()
                .Property(item => item.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Inventory>()
                .Property(inventory => inventory.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>()
                .Property(order => order.Id)
                .ValueGeneratedOnAdd();
        }*/
    }
}
