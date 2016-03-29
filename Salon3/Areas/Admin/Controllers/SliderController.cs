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
    public class SliderController : Controller
    {
        private sinemaEntities2 db = new sinemaEntities2();

        // GET: Admin/Slider
        public ActionResult Index()
        {
            return View(db.slayder.ToList());
        }

        // GET: Admin/Slider/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            slayder slayder = db.slayder.Find(id);
            if (slayder == null)
            {
                return HttpNotFound();
            }
            return View(slayder);
        }

        // GET: Admin/Slider/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Slider/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "slayderID,resimYol,adı")] slayder slayder)
        {
            if (ModelState.IsValid)
            {
                db.slayder.Add(slayder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slayder);
        }

        // GET: Admin/Slider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            slayder slayder = db.slayder.Find(id);
            if (slayder == null)
            {
                return HttpNotFound();
            }
            return View(slayder);
        }

        // POST: Admin/Slider/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "slayderID,resimYol,adı")] slayder slayder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slayder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slayder);
        }

        // GET: Admin/Slider/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            slayder slayder = db.slayder.Find(id);
            if (slayder == null)
            {
                return HttpNotFound();
            }
            return View(slayder);
        }

        // POST: Admin/Slider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            slayder slayder = db.slayder.Find(id);
            db.slayder.Remove(slayder);
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
