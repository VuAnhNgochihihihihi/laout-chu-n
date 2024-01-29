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
    public class ProductServiesController : Controller
    {
        private NexusmarketingEntities db = new NexusmarketingEntities();

        // GET: ProductServies
        public ActionResult Index()
        {
            return View(db.ProductServies.ToList());
        }

        // GET: ProductServies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductServy productServy = db.ProductServies.Find(id);
            if (productServy == null)
            {
                return HttpNotFound();
            }
            return View(productServy);
        }

        // GET: ProductServies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductServies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutID,Service_ID")] ProductServy productServy)
        {
            if (ModelState.IsValid)
            {
                db.ProductServies.Add(productServy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productServy);
        }

        // GET: ProductServies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductServy productServy = db.ProductServies.Find(id);
            if (productServy == null)
            {
                return HttpNotFound();
            }
            return View(productServy);
        }

        // POST: ProductServies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutID,Service_ID")] ProductServy productServy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productServy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productServy);
        }

        // GET: ProductServies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductServy productServy = db.ProductServies.Find(id);
            if (productServy == null)
            {
                return HttpNotFound();
            }
            return View(productServy);
        }

        // POST: ProductServies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductServy productServy = db.ProductServies.Find(id);
            db.ProductServies.Remove(productServy);
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
