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
    public class BookInfoesController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        // GET: api/BookInfoes
        public IQueryable<BookInfo> GetBookInfo()
        {
            return db.BookInfo;
        }

        // GET: api/BookInfoes/5
        [ResponseType(typeof(BookInfo))]
        public IHttpActionResult GetBookInfo(int id)
        {
            BookInfo bookInfo = db.BookInfo.Find(id);
            if (bookInfo == null)
            {
                return NotFound();
            }

            return Ok(bookInfo);
        }

        // PUT: api/BookInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBookInfo(int id, BookInfo bookInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bookInfo.Id)
            {
                return BadRequest();
            }

            db.Entry(bookInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookInfoExists(id))
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

        // POST: api/BookInfoes
        [ResponseType(typeof(BookInfo))]
        public IHttpActionResult PostBookInfo(BookInfo bookInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BookInfo.Add(bookInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bookInfo.Id }, bookInfo);
        }

        // DELETE: api/BookInfoes/5
        [ResponseType(typeof(BookInfo))]
        public IHttpActionResult DeleteBookInfo(int id)
        {
            BookInfo bookInfo = db.BookInfo.Find(id);
            if (bookInfo == null)
            {
                return NotFound();
            }

            db.BookInfo.Remove(bookInfo);
            db.SaveChanges();

            return Ok(bookInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookInfoExists(int id)
        {
            return db.BookInfo.Count(e => e.Id == id) > 0;
        }
    }
}