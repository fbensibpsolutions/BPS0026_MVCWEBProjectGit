using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPS0026_MVC_WEB.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderItem { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

    }
}