using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidly.Models;
using vidly.viewmodels;

namespace vidly.Controllers
{
    public class customersController : Controller
    {
        ApplicationDbContext db;
        public customersController()
        {
            db = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        // GET: customer
        public ActionResult Index()
        {
            //var customer = db.customers.Include(a => a.membershiptype).ToList();
            //return View(customer);
            return View();
        }
        public ActionResult details(int id)
        {
            var customer = db.customers.Include(cd => cd.membershiptype).SingleOrDefault(c => c.id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
        public ActionResult New(int? id)
        {
            if (id != null)
            {
                var customer = db.customers.SingleOrDefault(a => a.id == id);
                var cutomerview2 = new customerviewmodel()
                {
                    customer = customer,
                    membershiptype = db.membershiptypes.ToList()
                };
                return View("customerform", cutomerview2);


            }
            var membership = db.membershiptypes.ToList();
            var customerview = new customerviewmodel()
            {
                customer=new customer(),
                membershiptype = membership
            };
            return View("customerform", customerview);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult save(customerviewmodel customerview)
        {
            if (!ModelState.IsValid)
            {
                customerview.membershiptype = db.membershiptypes.ToList();
                return View("customerform", customerview);
            }
            var customer = new customer();
            if (customerview.customer.id == 0)
            {
                customer.name = customerview.customer.name;
                customer.issubscribedtonewsletter = customerview.customer.issubscribedtonewsletter;
                customer.birthdate = customerview.customer.birthdate;
                customer.membershiptypeid = customerview.customer.membershiptypeid;
                db.customers.Add(customer);
                db.SaveChanges();
            }
            else
            {
                customer = db.customers.SingleOrDefault(a => a.id == customerview.customer.id);
                customer.name = customerview.customer.name;
                customer.issubscribedtonewsletter = customerview.customer.issubscribedtonewsletter;
                customer.birthdate = customerview.customer.birthdate;
                customer.membershiptypeid = customerview.customer.membershiptypeid;
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("index","customers");
        }
        public ActionResult edit(int id)
        {
          
            return View();
        }
    }
}