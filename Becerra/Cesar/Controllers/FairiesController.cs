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
using Cesar.Models;

namespace Cesar.Controllers
{
    public class FairiesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Fairies
        public IQueryable<Fairy> GetFairies()
        {
            return db.Fairies;
        }

        // GET: api/Fairies/5
        [ResponseType(typeof(Fairy))]
        public IHttpActionResult GetFairy(int id)
        {
            Fairy fairy = db.Fairies.Find(id);
            if (fairy == null)
            {
                return NotFound();
            }

            return Ok(fairy);
        }

        // PUT: api/Fairies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFairy(int id, Fairy fairy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fairy.FairyID)
            {
                return BadRequest();
            }

            db.Entry(fairy).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FairyExists(id))
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

        // POST: api/Fairies
        [ResponseType(typeof(Fairy))]
        public IHttpActionResult PostFairy(Fairy fairy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fairies.Add(fairy);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fairy.FairyID }, fairy);
        }

        // DELETE: api/Fairies/5
        [ResponseType(typeof(Fairy))]
        public IHttpActionResult DeleteFairy(int id)
        {
            Fairy fairy = db.Fairies.Find(id);
            if (fairy == null)
            {
                return NotFound();
            }

            db.Fairies.Remove(fairy);
            db.SaveChanges();

            return Ok(fairy);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FairyExists(int id)
        {
            return db.Fairies.Count(e => e.FairyID == id) > 0;
        }
    }
}