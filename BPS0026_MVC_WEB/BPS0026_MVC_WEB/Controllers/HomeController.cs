using BPS0026_MVC_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BPS0026_MVC_WEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Order> orderList = new List<Order>();

            orderList = OrderDetailsData();

            return View(orderList);
        }

        public ActionResult Orderdetails(string no)
        {
            ViewData["no"] = no;

            var data = OrderDetailsData().FirstOrDefault(x => x.No == no);

            var orderdetailsdatas = new List<Order>();

            orderdetailsdatas.Add(new Order
            {
                No = data.No,
                CustomerName = data.CustomerName,
                Date = data.Date,
                Amount = data.Amount
            });

            return View(orderdetailsdatas);
        }


        public List<Order> OrderDetailsData()
        {
            var orders = new List<Order>();

            orders.Add(new Order
            {
                No = "OD-1",
                CustomerName = "Test-1",
                Date = DateTime.Now.ToString("MM/dd/yyyy"),
                Amount = 1000
            });
            orders.Add(new Order
            {
                No = "OD-2",
                CustomerName = "Test-2",
                Date = DateTime.Now.ToString("MM/dd/yyyy"),
                Amount = 1050
            });

            orders.Add(new Order
            {
                No = "OD-3",
                CustomerName = "Test-3",
                Date = DateTime.Now.ToString("MM/dd/yyyy"),
                Amount = 1050
            });

            orders.Add(new Order
            {
                No = "OD-4",
                CustomerName = "Test-4",
                Date = DateTime.Now.ToString("MM/dd/yyyy"),
                Amount = 1050
            });

            return orders;
        }
    }
}