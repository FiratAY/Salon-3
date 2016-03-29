using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Salon3.Models;

namespace Salon3.Areas.Admin.Controllers
{
    public class resimsController : Controller
    {
        private sinemaEntities2 db = new sinemaEntities2();

        // GET: Admin/resims
        public ActionResult Index()
        {
            var resim = db.resim.Include(r => r.film).Include(r => r.haber);
            return View(resim.ToList());
        }

        // GET: Admin/resims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resim resim = db.resim.Find(id);
            if (resim == null)
            {
                return HttpNotFound();
            }
            return View(resim);
        }

        // GET: Admin/resims/Create
        public ActionResult Create()
        {
            ViewBag.filmID = new SelectList(db.film, "filmID", "ad");
            ViewBag.haberID = new SelectList(db.haber, "haberID", "konu");
            return View();
        }

        // POST: Admin/resims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "resimID,ad,yol,haberID,filmID")] resim resim)
        {
            if (ModelState.IsValid)
            {
                db.resim.Add(resim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.filmID = new SelectList(db.film, "filmID", "ad", resim.filmID);
            ViewBag.haberID = new SelectList(db.haber, "haberID", "konu", resim.haberID);
            return View(resim);
        }

        // GET: Admin/resims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resim resim = db.resim.Find(id);
            if (resim == null)
            {
                return HttpNotFound();
            }
            ViewBag.filmID = new SelectList(db.film, "filmID", "ad", resim.filmID);
            ViewBag.haberID = new SelectList(db.haber, "haberID", "konu", resim.haberID);
            return View(resim);
        }

        // POST: Admin/resims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "resimID,ad,yol,haberID,filmID")] resim resim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.filmID = new SelectList(db.film, "filmID", "ad", resim.filmID);
            ViewBag.haberID = new SelectList(db.haber, "haberID", "konu", resim.haberID);
            return View(resim);
        }

        // GET: Admin/resims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            resim resim = db.resim.Find(id);
            if (resim == null)
            {
                return HttpNotFound();
            }
            return View(resim);
        }

        // POST: Admin/resims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            resim resim = db.resim.Find(id);
            db.resim.Remove(resim);
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
