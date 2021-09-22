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
        private OrderContext db = new OrderContext();

        public ActionResult CustomerHome()
        {
            return View(db.tbl_000_CustomerOrder.ToList());
        }


        public ActionResult Orderdetails(int? id, string no)
        {
            ViewData["no"] = no;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order orders = db.tbl_000_CustomerOrder.Find(id);
            if (orders == null)
            {
                return HttpNotFound();
            }

            return View(orders);
        }

        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCustomer([Bind(Include = "no,customername, date,amount")] Order orderModel)
        {
            if (ModelState.IsValid)
            {
                db.tbl_000_CustomerOrder.Add(orderModel);
                db.SaveChangesAsync();
                return Redirect("CustomerHome");
            }
            return View(orderModel);
        }


        public ActionResult EditCustomer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order orderModel = db.tbl_000_CustomerOrder.Find(id);
            if (orderModel == null)
            {
                return HttpNotFound();
            }
            return View(orderModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitEditData([Bind(Include = "Id,no,customername, date,amount")] Order orderModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderModel).State = EntityState.Modified;
                db.SaveChangesAsync();
                return Redirect("CustomerHome");
            }
            return View(orderModel);
        }
        public ActionResult DeleteCustomer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order orderModel = db.tbl_000_CustomerOrder.Find(id);
            if (orderModel == null)
            {
                return HttpNotFound();
            }
            return View(orderModel);
        }

        //[HttpPost, ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order orderModel = db.tbl_000_CustomerOrder.Find(id);
            db.tbl_000_CustomerOrder.Remove(orderModel);
            db.SaveChanges();
            return Redirect("CustomerHome");
        }
    }
}