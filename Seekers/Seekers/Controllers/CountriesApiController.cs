using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Seekers.Models;

namespace Seekers.Controllers
{
    public class CountriesApiController : ApiController
    {
        private UsersContext db = new UsersContext();

        // GET api/CountriesApi
        public IEnumerable<Country> GetCountries()
        {
            return db.Countries.AsEnumerable();
        }

        // GET api/CountriesApi/5
        public Country GetCountry(int id)
        {
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return country;
        }

        // PUT api/CountriesApi/5
        public HttpResponseMessage PutCountry(int id, Country country)
        {
            if (ModelState.IsValid && id == country.id)
            {
                db.Entry(country).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/CountriesApi
        public HttpResponseMessage PostCountry(Country country)
        {
            if (ModelState.IsValid)
            {
                db.Countries.Add(country);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, country);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = country.id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/CountriesApi/5
        public HttpResponseMessage DeleteCountry(int id)
        {
            Country country = db.Countries.Find(id);
            if (country == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Countries.Remove(country);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, country);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}