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
    public class CitiesController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Cities/

        public ActionResult Index()
        {
            var cities = db.Cities.Include(c => c.country);
            return View(cities.ToList());
        }

        //
        // GET: /Cities/Details/5

        public ActionResult Details(int id = 0)
        {
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        //
        // GET: /Cities/Create

        public ActionResult Create()
        {
            ViewBag.countryId = new SelectList(db.Countries, "id", "name");
            return View();
        }

        //
        // POST: /Cities/Create

        [HttpPost]
        public ActionResult Create(City city)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.countryId = new SelectList(db.Countries, "id", "name", city.countryId);
            return View(city);
        }

        //
        // GET: /Cities/Edit/5

        public ActionResult Edit(int id = 0)
        {
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            ViewBag.countryId = new SelectList(db.Countries, "id", "name", city.countryId);
            return View(city);
        }

        //
        // POST: /Cities/Edit/5

        [HttpPost]
        public ActionResult Edit(City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.countryId = new SelectList(db.Countries, "id", "name", city.countryId);
            return View(city);
        }

        //
        // GET: /Cities/Delete/5

        public ActionResult Delete(int id = 0)
        {
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        //
        // POST: /Cities/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            City city = db.Cities.Find(id);
            db.Cities.Remove(city);
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