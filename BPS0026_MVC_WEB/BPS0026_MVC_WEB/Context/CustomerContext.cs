using BPS0026_MVC_WEB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BPS0026_MVC_WEB.Context
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Tbl_000_Customer { get; set; }
        public DbSet<Order> Tbl_000_Order { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customers");
            //pk customerid
            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);
            //Identiy key for the customer id
            modelBuilder.Entity<Customer>().Property(c => c.CustomerId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Customer>().Property(c => c.No).IsMaxLength();

            modelBuilder.Entity<Customer>().Property(c => c.Date).HasColumnType("datetime2");

            modelBuilder.Entity<Customer>().Property(c => c.CustomerName).HasMaxLength(50);

            modelBuilder.Entity<Customer>().Property(c => c.Amount);




            modelBuilder.Entity<Order>().ToTable("Orders");
            //pk OrderId
            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
            //Identiy key for the customer id
            modelBuilder.Entity<Order>().Property(o => o.OrderId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Order>().Property(o => o.Item).HasMaxLength(50);

            modelBuilder.Entity<Order>().Property(o => o.Date).HasColumnType("datetime2");

            modelBuilder.Entity<Order>().Property(o => o.Quantity);

            modelBuilder.Entity<Order>().Property(o => o.Price).HasColumnType("float");

            //one to many relationship
            modelBuilder.Entity<Order>().HasRequired<Customer>(b => b.Customers).WithMany(a => a.Orders).HasForeignKey<int>(b => b.CustomerId);

            base.OnModelCreating(modelBuilder);

        }
    }
}