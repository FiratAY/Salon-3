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
    public class videosController : Controller
    {
        private sinemaEntities2 db = new sinemaEntities2();

        // GET: Admin/videos
        public ActionResult Index()
        {
            var video = db.video.Include(v => v.film);
            return View(video.ToList());
        }

        // GET: Admin/videos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            video video = db.video.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // GET: Admin/videos/Create
        public ActionResult Create()
        {
            ViewBag.filmID = new SelectList(db.film, "filmID", "ad");
            return View();
        }

        // POST: Admin/videos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "videoID,filmID,yol,ad")] video video)
        {
            if (ModelState.IsValid)
            {
                db.video.Add(video);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.filmID = new SelectList(db.film, "filmID", "ad", video.filmID);
            return View(video);
        }

        // GET: Admin/videos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            video video = db.video.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            ViewBag.filmID = new SelectList(db.film, "filmID", "ad", video.filmID);
            return View(video);
        }

        // POST: Admin/videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "videoID,filmID,yol,ad")] video video)
        {
            if (ModelState.IsValid)
            {
                db.Entry(video).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.filmID = new SelectList(db.film, "filmID", "ad", video.filmID);
            return View(video);
        }

        // GET: Admin/videos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            video video = db.video.Find(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: Admin/videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            video video = db.video.Find(id);
            db.video.Remove(video);
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
