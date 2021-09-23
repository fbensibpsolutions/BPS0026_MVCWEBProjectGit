using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BPS0026_MVC_WEB.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string No { get; set; }
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
        public int Amount { get; set; }

    }
}