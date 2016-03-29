using Salon3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Salon3.Controllers
{
    public class FilmlerController : Controller
    {
        sinemaEntities2 db = new sinemaEntities2();
        // GET: Filmler
        public ActionResult Detay(int id)
        {
            ViewBag.vid=db.video.FirstOrDefault(y => y.filmID == id);
            ViewBag.resim= db.resim.FirstOrDefault(y => y.filmID == id);
            ViewBag.film = db.film.FirstOrDefault(x => x.filmID == id);
            return View();
        }
    }
}