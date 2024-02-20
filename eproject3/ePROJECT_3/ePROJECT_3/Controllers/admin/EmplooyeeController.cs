using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ePROJECT_3.Models;

namespace ePROJECT_3.Controllers.admin
{
    public class EmplooyeeController : Controller
    {
        private NexusmarketingEntities db = new NexusmarketingEntities();

        // GET: Emplooyee
        public ActionResult Index()
        {
            return View(db.Emplooyees.ToList());
        }

        // GET: Emplooyee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emplooyee emplooyee = db.Emplooyees.Find(id);
            if (emplooyee == null)
            {
                return HttpNotFound();
            }
            return View(emplooyee);
        }

        public ActionResult Login()
        {
            Emplooyee emplooyee = new Emplooyee();
            if (Request.Cookies["UserName"] != null)
            {
                emplooyee.UserName = Request.Cookies["UserName"].Value;
                emplooyee.Remember = true;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer obj)
        {
            var ePloyee = db.Emplooyees.Where(c => c.UserName == obj.UserName && c.Password == obj.Password);

            if (ePloyee.ToList().Count > 0)
            {
                if (obj.Remember)
                {
                    Response.Cookies["UserName"].Value = obj.UserName;
                    Response.Cookies["UserName"].Expires = DateTime.MaxValue;
                }
                Session["UserName"] = obj.UserName;
                Session["Employee_ID"] = ePloyee.ToList()[0].Employee_ID;
            }
            else
            {
                return Content("Sai UserName hoặc Password");
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Emplooyee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emplooyee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Employee_ID,EmployeeName,UserName,Password,email,address,phone_number,created_at")] Emplooyee emplooyee)
        {
            if (ModelState.IsValid)
            {
                db.Emplooyees.Add(emplooyee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emplooyee);
        }

        // GET: Emplooyee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emplooyee emplooyee = db.Emplooyees.Find(id);
            if (emplooyee == null)
            {
                return HttpNotFound();
            }
            return View(emplooyee);
        }

        // POST: Emplooyee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Employee_ID,EmployeeName,UserName,Password,email,address,phone_number,created_at")] Emplooyee emplooyee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emplooyee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emplooyee);
        }

        // GET: Emplooyee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emplooyee emplooyee = db.Emplooyees.Find(id);
            if (emplooyee == null)
            {
                return HttpNotFound();
            }
            return View(emplooyee);
        }

        // POST: Emplooyee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emplooyee emplooyee = db.Emplooyees.Find(id);
            db.Emplooyees.Remove(emplooyee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
