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
using LibraryRedux.DataContext;
using LibraryRedux.Models;

namespace LibraryRedux.Controllers
{
    public class PatronInfoesController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        // GET: api/PatronInfoes
        public IQueryable<PatronInfo> GetPatronInfo()
        {
            return db.PatronInfo;
        }

        // GET: api/PatronInfoes/5
        [ResponseType(typeof(PatronInfo))]
        public IHttpActionResult GetPatronInfo(int id)
        {
            PatronInfo patronInfo = db.PatronInfo.Find(id);
            if (patronInfo == null)
            {
                return NotFound();
            }

            return Ok(patronInfo);
        }

        // PUT: api/PatronInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPatronInfo(int id, PatronInfo patronInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != patronInfo.Id)
            {
                return BadRequest();
            }

            db.Entry(patronInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatronInfoExists(id))
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

        // POST: api/PatronInfoes
        [ResponseType(typeof(PatronInfo))]
        public IHttpActionResult PostPatronInfo(PatronInfo patronInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PatronInfo.Add(patronInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = patronInfo.Id }, patronInfo);
        }

        // DELETE: api/PatronInfoes/5
        [ResponseType(typeof(PatronInfo))]
        public IHttpActionResult DeletePatronInfo(int id)
        {
            PatronInfo patronInfo = db.PatronInfo.Find(id);
            if (patronInfo == null)
            {
                return NotFound();
            }

            db.PatronInfo.Remove(patronInfo);
            db.SaveChanges();

            return Ok(patronInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PatronInfoExists(int id)
        {
            return db.PatronInfo.Count(e => e.Id == id) > 0;
        }
    }
}