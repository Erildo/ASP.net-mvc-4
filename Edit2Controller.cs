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
    public class Edit2Controller : Controller
    {
        private udb db = new udb();

        //
        // GET: /Edit2/

        public ActionResult Index()
        {
            var seuni = db.Seuni.Include(s => s.Klasa);
            return View(seuni.ToList());
        }

        //
        // GET: /Edit2/Details/5

        public ActionResult Details(int id = 0)
        {
            student student = db.Seuni.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // GET: /Edit2/Create

        public ActionResult Create()
        {
            ViewBag.klasaid = new SelectList(db.Keuni, "klasaid", "emriklases");
            return View();
        }

        //
        // POST: /Edit2/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(student student)
        {
            if (ModelState.IsValid)
            {
                db.Seuni.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.klasaid = new SelectList(db.Keuni, "klasaid", "emriklases", student.klasaid);
            return View(student);
        }

        //
        // GET: /Edit2/Edit/5

        public ActionResult Edit(int id = 0)
        {
            student student = db.Seuni.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.klasaid = new SelectList(db.Keuni, "klasaid", "emriklases", student.klasaid);
            return View(student);
        }

        //
        // POST: /Edit2/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.klasaid = new SelectList(db.Keuni, "klasaid", "emriklases", student.klasaid);
            return View(student);
        }

        //
        // GET: /Edit2/Delete/5

        public ActionResult Delete(int id = 0)
        {
            student student = db.Seuni.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        //
        // POST: /Edit2/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student student = db.Seuni.Find(id);
            db.Seuni.Remove(student);
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