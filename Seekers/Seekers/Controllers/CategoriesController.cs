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
    public class CategoriesController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Categories/

        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        //
        // GET: /Categories/Details/5

        public ActionResult Details(int id = 0)
        {
            Catogery catogery = db.Categories.Find(id);
            if (catogery == null)
            {
                return HttpNotFound();
            }
            return View(catogery);
        }

        //
        // GET: /Categories/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Categories/Create

        [HttpPost]
        public ActionResult Create(Catogery catogery)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(catogery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catogery);
        }

        //
        // GET: /Categories/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Catogery catogery = db.Categories.Find(id);
            if (catogery == null)
            {
                return HttpNotFound();
            }
            return View(catogery);
        }

        //
        // POST: /Categories/Edit/5

        [HttpPost]
        public ActionResult Edit(Catogery catogery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catogery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catogery);
        }

        //
        // GET: /Categories/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Catogery catogery = db.Categories.Find(id);
            if (catogery == null)
            {
                return HttpNotFound();
            }
            return View(catogery);
        }

        //
        // POST: /Categories/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Catogery catogery = db.Categories.Find(id);
            db.Categories.Remove(catogery);
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