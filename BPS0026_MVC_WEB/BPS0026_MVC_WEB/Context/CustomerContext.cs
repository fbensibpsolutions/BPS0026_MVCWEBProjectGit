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
        public DbSet<Customers> Tbl_000_Customer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //pk customerid
            modelBuilder.Entity<Customers>().HasKey(c => c.CustomerId);
            //Identiy key for the customer id
            modelBuilder.Entity<Customers>().Property(c => c.CustomerId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Customers>().Property(c => c.No).IsMaxLength();

            modelBuilder.Entity<Customers>().Property(c => c.Date).HasMaxLength(10);

            modelBuilder.Entity<Customers>().Property(c => c.CustomerName).HasMaxLength(50);

            modelBuilder.Entity<Customers>().Property(c => c.Amount);

            base.OnModelCreating(modelBuilder);
        }
    }
}