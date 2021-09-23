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

            Customer Customers = db.Tbl_000_Customer.Find(customerid);
            if (Customers == null)
            {
                return HttpNotFound();
            }

            return View(Customers);
        }

        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCustomer([Bind(Include = "no,customername, date,amount")] Customer Customers)
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
        public ActionResult SubmitEditData([Bind(Include = "customerid,no,customername, date,amount")] Customer Customers)
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
        public ActionResult DeleteConfirmed(int customerid)
        {
            Customer Customers = db.Tbl_000_Customer.Find(customerid);
            db.Tbl_000_Customer.Remove(Customers);
            db.SaveChanges();
            return Redirect("CustomerHome");
        }
    }
}