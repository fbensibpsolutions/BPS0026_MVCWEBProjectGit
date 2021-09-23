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

            base.OnModelCreating(modelBuilder);
        }
    }
}