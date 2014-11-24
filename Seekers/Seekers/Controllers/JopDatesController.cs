using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Seekers.Models;

namespace Seekers.Controllers
{
    public class JopDatesController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /JopDates/

        public ActionResult Index()
        {
            var jopdates = db.JopDates.Include(j => j.jop).Include(j => j.category);
            return View(jopdates.ToList());
        }

        //
        // GET: /JopDates/Details/5

        public ActionResult Details(int id = 0)
        {
            JopDate jopdate = db.JopDates.Find(id);
            if (jopdate == null)
            {
                return HttpNotFound();
            }
            return View(jopdate);
        }

        //
        // GET: /JopDates/Create

        public ActionResult Create()
        {
            ViewBag.jopId = new SelectList(db.Jops, "id", "name");
            ViewBag.categoryId = new SelectList(db.Categories, "id", "name");
            return View();
        }

        //
        // POST: /JopDates/Create

        [HttpPost]
        public ActionResult Create(JopDate jopdate)
        {
            if (ModelState.IsValid)
            {
                db.JopDates.Add(jopdate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.jopId = new SelectList(db.Jops, "id", "name", jopdate.jopId);
            ViewBag.categoryId = new SelectList(db.Categories, "id", "name", jopdate.categoryId);
            return View(jopdate);
        }

        //
        // GET: /JopDates/Edit/5

        public ActionResult Edit(int id = 0)
        {
            JopDate jopdate = db.JopDates.Find(id);
            if (jopdate == null)
            {
                return HttpNotFound();
            }
            ViewBag.jopId = new SelectList(db.Jops, "id", "name", jopdate.jopId);
            ViewBag.categoryId = new SelectList(db.Categories, "id", "name", jopdate.categoryId);
            return View(jopdate);
        }

        //
        // POST: /JopDates/Edit/5

        [HttpPost]
        public ActionResult Edit(JopDate jopdate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jopdate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.jopId = new SelectList(db.Jops, "id", "name", jopdate.jopId);
            ViewBag.categoryId = new SelectList(db.Categories, "id", "name", jopdate.categoryId);
            return View(jopdate);
        }

        //
        // GET: /JopDates/Delete/5

        public ActionResult Delete(int id = 0)
        {
            JopDate jopdate = db.JopDates.Find(id);
            if (jopdate == null)
            {
                return HttpNotFound();
            }
            return View(jopdate);
        }

        //
        // POST: /JopDates/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            JopDate jopdate = db.JopDates.Find(id);
            db.JopDates.Remove(jopdate);
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