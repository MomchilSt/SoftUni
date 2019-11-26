using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Sales;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingProduct(modelBuilder);

            OnModelCreatingCustomer(modelBuilder);

            OnModelCreatingStore(modelBuilder);

            OnModelCreatingSales(modelBuilder);
        }

        private void OnModelCreatingSales(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Sale>()
                .HasKey(s => s.SaleId);

            modelBuilder
                .Entity<Sale>()
                .HasOne(s => s.Store)
                .WithMany(s => s.Sales);

            modelBuilder
                .Entity<Sale>()
                .Property(s => s.Date)
                .HasDefaultValueSql("GETDATE()");
        }

        private void OnModelCreatingStore(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Store>()
                .HasKey(s => s.StoreId);

            modelBuilder
                .Entity<Store>()
                .Property(s => s.Name)
                .HasMaxLength(80)
                .IsUnicode();

            modelBuilder
                .Entity<Store>()
                .HasMany(s => s.Sales)
                .WithOne(s => s.Store);
        }

        private void OnModelCreatingCustomer(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<Customer>()
                 .HasKey(c => c.CustomerId);

            modelBuilder
                .Entity<Customer>()
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsUnicode();

            modelBuilder
                .Entity<Customer>()
                .Property(c => c.Email)
                .HasMaxLength(80);

            modelBuilder
                .Entity<Customer>()
                .HasMany(c => c.Sales)
                .WithOne(s => s.Customer);
        }

        private void OnModelCreatingProduct(ModelBuilder modelBuilder)
        {
            modelBuilder
                 .Entity<Product>()
                 .HasKey(p => p.ProductId);

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder
                .Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(250);

            modelBuilder
                .Entity<Product>()
                .HasMany(p => p.Sales)
                .WithOne(s => s.Product);
        }
    }
}
