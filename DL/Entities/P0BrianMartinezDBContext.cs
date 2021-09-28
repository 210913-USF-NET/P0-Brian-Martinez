using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DL.Entities
{
    public partial class P0BrianMartinezDBContext : DbContext
    {
        public P0BrianMartinezDBContext()
        {
        }

        public P0BrianMartinezDBContext(DbContextOptions<P0BrianMartinezDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<LineItem> LineItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StoreFront> StoreFronts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("Inventory");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Inventory__Produ__10566F31");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Inventory__Store__0F624AF8");
            });

            modelBuilder.Entity<LineItem>(entity =>
            {
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__LineItems__Order__2180FB33");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__LineItems__Produ__22751F6C");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.LineItems)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__LineItems__Store__236943A5");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__160F4887");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<StoreFront>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
