using BPS0026_MVC_WEB.Context;
using BPS0026_MVC_WEB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BPS0026_MVC_WEB.Controllers
{
    public class HomeController : Controller
    {

        public CustomerContext db = new CustomerContext();

        public ActionResult CustomerHome()
        {
            return View(db.Tbl_000_Customer.ToList());
        }


        public ActionResult Orderdetails(int? customerid, string no)
        {
            ViewData["no"] = no;
            if (customerid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Customers Customer = db.Tbl_000_Customer.Find(customerid);
            if (Customer == null)
            {
                return HttpNotFound();
            }

            return View(Customer);
        }

        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCustomer([Bind(Include = "no,customername, date,amount")] Customers Customer)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_000_Customer.Add(Customer);
                db.SaveChangesAsync();
                return Redirect("CustomerHome");
            }
            return View(Customer);
        }


        public ActionResult EditCustomer(int? customerid)
        {
            if (customerid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers Customer = db.Tbl_000_Customer.Find(customerid);
            if (Customer == null)
            {
                return HttpNotFound();
            }
            return View(Customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitEditData([Bind(Include = "customerid,no,customername, date,amount")] Customers Customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Customer).State = EntityState.Modified;
                db.SaveChangesAsync();
                return Redirect("CustomerHome");
            }
            return View(Customer);
        }
        public ActionResult DeleteCustomer(int? customerid)
        {
            if (customerid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers Customer = db.Tbl_000_Customer.Find(customerid);
            if (Customer == null)
            {
                return HttpNotFound();
            }
            return View(Customer);
        }

        //[HttpPost, ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int customerid)
        {
            Customers Customer = db.Tbl_000_Customer.Find(customerid);
            db.Tbl_000_Customer.Remove(Customer);
            db.SaveChanges();
            return Redirect("CustomerHome");
        }
    }
}