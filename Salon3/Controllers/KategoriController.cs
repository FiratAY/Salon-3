using Salon3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Salon3.Controllers
{
    public class KategoriController : Controller
    {
        sinemaEntities2 db = new sinemaEntities2();
        // GET: Kategori
        public ActionResult Index(int id)
        {
            ViewBag.resim = db.resim;
            ViewBag.filmler = db.film.Where(x => x.kategoriID == id).OrderByDescending(x=>x.eklemeTarihi);
            return View();
        }
    }
}