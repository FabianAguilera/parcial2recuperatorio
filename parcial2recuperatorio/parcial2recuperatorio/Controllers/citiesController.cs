using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using parcial2recuperatorio.Models;

namespace parcial2recuperatorio.Controllers
{
    public class citiesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/cities
        public IQueryable<city> Getcities()
        {
            return db.cities;
        }

        // GET: api/cities/5
        [ResponseType(typeof(city))]
        public IHttpActionResult Getcity(string id)
        {
            city city = db.cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        // PUT: api/cities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcity(string id, city city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != city.Name)
            {
                return BadRequest();
            }

            db.Entry(city).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/cities
        [ResponseType(typeof(city))]
        public IHttpActionResult Postcity(city city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cities.Add(city);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (cityExists(city.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = city.Name }, city);
        }

        // DELETE: api/cities/5
        [ResponseType(typeof(city))]
        public IHttpActionResult Deletecity(string id)
        {
            city city = db.cities.Find(id);
            if (city == null)
            {
                return NotFound();
            }

            db.cities.Remove(city);
            db.SaveChanges();

            return Ok(city);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool cityExists(string id)
        {
            return db.cities.Count(e => e.Name == id) > 0;
        }
    }
}