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
    public class ojbectsController : Controller
    {
        private NexusmarketingEntities db = new NexusmarketingEntities();

        // GET: ojbects
        public ActionResult Index()
        {
            return View(db.ojbects.ToList());
        }

        // GET: ojbects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ojbect ojbect = db.ojbects.Find(id);
            if (ojbect == null)
            {
                return HttpNotFound();
            }
            return View(ojbect);
        }

        // GET: ojbects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ojbects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ojbectID,ojbectName")] ojbect ojbect)
        {
            if (ModelState.IsValid)
            {
                db.ojbects.Add(ojbect);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ojbect);
        }

        // GET: ojbects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ojbect ojbect = db.ojbects.Find(id);
            if (ojbect == null)
            {
                return HttpNotFound();
            }
            return View(ojbect);
        }

        // POST: ojbects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ojbectID,ojbectName")] ojbect ojbect)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ojbect).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ojbect);
        }

        // GET: ojbects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ojbect ojbect = db.ojbects.Find(id);
            if (ojbect == null)
            {
                return HttpNotFound();
            }
            return View(ojbect);
        }

        // POST: ojbects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ojbect ojbect = db.ojbects.Find(id);
            db.ojbects.Remove(ojbect);
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
