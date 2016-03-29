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
    [Authorize(Roles = "yonetici")]
    public class filmAdminController : Controller
    {
        private sinemaEntities2 db = new sinemaEntities2();

        // GET: Admin/films
        public ActionResult Index()
        {
            var film = db.film.Include(f => f.admin).Include(f => f.Kategori);
            return View(film.ToList());
        }

        // GET: Admin/films/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            film film = db.film.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: Admin/films/Create
        public ActionResult Create()
        {
            ViewBag.adminID = new SelectList(db.admin, "adminID", "ad");
            ViewBag.kategoriID = new SelectList(db.Kategori, "kategoriID", "kategoriad");
            return View();
        }

        // POST: Admin/films/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "filmID,adminID,ad,begeni,yonetmen,vizyon,eklemeTarihi,imdb,kategoriID,ozet")] film film)
        {
            if (ModelState.IsValid)
            {
                db.film.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.adminID = new SelectList(db.admin, "adminID", "ad", film.adminID);
            ViewBag.kategoriID = new SelectList(db.Kategori, "kategoriID", "kategoriad", film.kategoriID);
            return View(film);
        }

        // GET: Admin/films/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            film film = db.film.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            ViewBag.adminID = new SelectList(db.admin, "adminID", "ad", film.adminID);
            ViewBag.kategoriID = new SelectList(db.Kategori, "kategoriID", "kategoriad", film.kategoriID);
            return View(film);
        }

        // POST: Admin/films/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "filmID,adminID,ad,begeni,yonetmen,vizyon,eklemeTarihi,imdb,kategoriID,ozet")] film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.adminID = new SelectList(db.admin, "adminID", "ad", film.adminID);
            ViewBag.kategoriID = new SelectList(db.Kategori, "kategoriID", "kategoriad", film.kategoriID);
            return View(film);
        }

        // GET: Admin/films/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            film film = db.film.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Admin/films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            film film = db.film.Find(id);
            db.film.Remove(film);
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
