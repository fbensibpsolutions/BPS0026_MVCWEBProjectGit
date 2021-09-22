using BPS0026_MVC_WEB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BPS0026_MVC_WEB.Context
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> tbl_000_CustomerOrder { get; set; }
    }
}