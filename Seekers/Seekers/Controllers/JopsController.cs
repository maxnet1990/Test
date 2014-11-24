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
    public class JopsController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Jops/

        public ActionResult Index()
        {
            var jops = db.Jops.Include(j => j.city);
            return View(jops.ToList());
        }

        //
        // GET: /Jops/Details/5

        public ActionResult Details(int id = 0)
        {
            Jop jop = db.Jops.Find(id);
            if (jop == null)
            {
                return HttpNotFound();
            }
            return View(jop);
        }

        //
        // GET: /Jops/Create

        public ActionResult Create()
        {
            ViewBag.cityId = new SelectList(db.Cities, "id", "name");
            return View();
        }

        //
        // POST: /Jops/Create

        [HttpPost]
        public ActionResult Create(Jop jop)
        {
            if (ModelState.IsValid)
            {
                db.Jops.Add(jop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cityId = new SelectList(db.Cities, "id", "name", jop.cityId);
            return View(jop);
        }

        //
        // GET: /Jops/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Jop jop = db.Jops.Find(id);
            if (jop == null)
            {
                return HttpNotFound();
            }
            ViewBag.cityId = new SelectList(db.Cities, "id", "name", jop.cityId);
            return View(jop);
        }

        //
        // POST: /Jops/Edit/5

        [HttpPost]
        public ActionResult Edit(Jop jop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cityId = new SelectList(db.Cities, "id", "name", jop.cityId);
            return View(jop);
        }

        //
        // GET: /Jops/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Jop jop = db.Jops.Find(id);
            if (jop == null)
            {
                return HttpNotFound();
            }
            return View(jop);
        }

        //
        // POST: /Jops/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Jop jop = db.Jops.Find(id);
            db.Jops.Remove(jop);
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