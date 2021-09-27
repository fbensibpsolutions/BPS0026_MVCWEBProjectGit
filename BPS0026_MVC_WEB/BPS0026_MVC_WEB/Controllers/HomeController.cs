using BPS0026_MVC_WEB.Context;
using BPS0026_MVC_WEB.Models;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace BPS0026_MVC_WEB.Controllers
{
    public class HomeController : Controller
    {

        public CustomerContext db = new CustomerContext();

        //Customer
        public ActionResult CustomerHome()
        {
            return View(db.Tbl_000_Customer.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCustomer([Bind(Include = "no,customername, date")] Customer Customers)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_000_Customer.Add(Customers);
                db.SaveChangesAsync();
                return Redirect("CustomerHome");
            }
            return View(Customers);
        }

        public ActionResult EditCustomer(int? customerid)
        {
            if (customerid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer Customers = db.Tbl_000_Customer.Find(customerid);
            if (Customers == null)
            {
                return HttpNotFound();
            }
            return View(Customers);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmedEditCustomer([Bind(Include = "customerid,no,customername, date")] Customer Customers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Customers).State = EntityState.Modified;
                db.SaveChangesAsync();
                return Redirect("CustomerHome");
            }
            return View(Customers);
        }
       
        public ActionResult DeleteCustomer(int? customerid)
        {
            if (customerid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer Customers = db.Tbl_000_Customer.Find(customerid);
            if (Customers == null)
            {
                return HttpNotFound();
            }
            return View(Customers);
        }

        //[HttpPost, ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmedDeleteCustomer(int customerid)
        {
            Customer Customers = db.Tbl_000_Customer.Find(customerid);
            db.Tbl_000_Customer.Remove(Customers);
            db.SaveChanges();
            return Redirect("CustomerHome");
        }

        //Order
        public ActionResult OrderHome()
        {

            dynamic dynamicModel = new ExpandoObject();

            dynamicModel.CustomerList = db.Tbl_000_Customer.ToList();
            dynamicModel.OrderList = db.Tbl_000_Order.ToList();

            return View(dynamicModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveOrder([Bind(Include = "no,customerid, date, amount")] Order Orders)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_000_Order.Add(Orders);
                db.SaveChangesAsync();
                return Redirect("OrderHome");
            }
            return View(Orders);
        }

        public ActionResult Orderdetails(int? customerid, string no)
        {
            dynamic dynamicModel = new ExpandoObject();

            ViewData["no"] = no;

            if (customerid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            dynamicModel.ordersDetailsList = db.Tbl_000_Order.ToList().Where(x => x.No == no && x.CustomerId == customerid);

            if (dynamicModel == null)
            {
                return HttpNotFound();
            }

            return View(dynamicModel);
        }

    }
}