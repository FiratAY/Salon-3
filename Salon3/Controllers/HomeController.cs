using Salon3.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Salon3.Controllers
{
    public class HomeController : Controller
    {
        sinemaEntities2 db = new sinemaEntities2();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Aksiyon()
        {
            

            return View();
        }
        public ActionResult Bilimkurgu()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Dram()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Komedi()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Korku()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult _HaftanınFilmleri()
        {
            ViewBag.film = db.film.Take(3);
            ViewBag.resim = db.resim;

            return View();
        }
        public ActionResult _Vizyonda()
        {
            ViewBag.film = db.film.Where(x=>x.vizyon=="vizyonda").Take(3);
            ViewBag.resim = db.resim;

            return View();
        }
        public ActionResult _Begenilenler()
        {
            ViewBag.film = db.film.OrderByDescending(x=>x.imdb).Take(3);
            ViewBag.resim = db.resim;

            return View();
        }
        public ActionResult _Slayder()
        {
            ViewBag.resim = db.resim.Take(3);

            return View();
        }
        public ActionResult _SizinSectikleriniz()
        {
            ViewBag.resim = db.resim;
            ViewBag.film = db.film.OrderByDescending(x=>x.begeni).Take(15);

            return View();
        }
        public ActionResult _SonEklenenler()
        {
            ViewBag.resim = db.resim;
            ViewBag.film = db.film.OrderByDescending(x => x.eklemeTarihi);

            return View();
        }
        public ActionResult _Menu()
        {
            ViewBag.kategori = db.Kategori.Take(5);

            return View();
        }
        public ActionResult liste(int id)
        {
            var data = db.film.OrderByDescending(y=>y.eklemeTarihi).Where(x => x.kategoriID == id);
            return View("FilmListele", data);
        }
        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }
    }
}