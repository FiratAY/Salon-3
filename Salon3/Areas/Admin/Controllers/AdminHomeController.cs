using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Salon3.Areas.Admin.Controllers
{
    [Authorize(Roles="yonetici")]
    public class AdminHomeController : Controller
    {
        // GET: Admin/Default
        public ActionResult Index()
        {
            return View();
        }
    }
}