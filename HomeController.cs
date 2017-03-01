using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unilast.Models;
using PagedList;
namespace Uni.Controllers
{
    public class HomeController : Controller
    {
        udb _db = new udb();

        public ActionResult Index(string searchterm = null, int page = 1)
        {
            var model = _db.Seuni
                       .OrderByDescending(r => r.nota)
                       .Where(r => searchterm == null || r.emristudent.StartsWith(searchterm))
                       .ToPagedList(page, 15);


            if (Request.IsAjaxRequest())
            {
                return PartialView("_partial", model);
            }
            return View(model);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
