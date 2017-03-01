using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unilast.Models;

namespace Unilast.Controllers
{
    public class Klasat2Controller : Controller
    {
        private udb db = new udb();

        //
        // GET: /Klasat2/

        public ActionResult Index()
        {
            return View(db.Keuni.ToList());
        }

        //
        // GET: /Klasat2/Details/5

        public ActionResult Details(int id = 0)
        {
            klasa klasa = db.Keuni.Find(id);
            if (klasa == null)
            {
                return HttpNotFound();
            }
            return View(klasa);
        }

        //
        // GET: /Klasat2/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Klasat2/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(klasa klasa)
        {
            if (ModelState.IsValid)
            {
                db.Keuni.Add(klasa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(klasa);
        }

        //
        // GET: /Klasat2/Edit/5

        public ActionResult Edit(int id = 0)
        {
            klasa klasa = db.Keuni.Find(id);
            if (klasa == null)
            {
                return HttpNotFound();
            }
            return View(klasa);
        }

        //
        // POST: /Klasat2/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(klasa klasa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(klasa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(klasa);
        }

        //
        // GET: /Klasat2/Delete/5

        public ActionResult Delete(int id = 0)
        {
            klasa klasa = db.Keuni.Find(id);
            if (klasa == null)
            {
                return HttpNotFound();
            }
            return View(klasa);
        }

        //
        // POST: /Klasat2/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            klasa klasa = db.Keuni.Find(id);
            db.Keuni.Remove(klasa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}