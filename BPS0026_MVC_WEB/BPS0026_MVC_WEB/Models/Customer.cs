using System;
using System.Collections.Generic;

namespace BPS0026_MVC_WEB.Models
{
    public class Customer
    {
        //primary key
        public int CustomerId { get; set; }
        public string No { get; set; }
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
        public int Amount { get; set; }

        //reverse navigation property
        public virtual ICollection<Order> Orders { get; set; }
        
    }

    public class Order
    {
       //primary key
        public int OrderId { get; set; }
        public string Item { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }


        //navigation property
        //foriegn key
        public int CustomerId { get; set; }
        public virtual Customer Customers { get; set; }
    }
}