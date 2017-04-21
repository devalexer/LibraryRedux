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
    public class TransactionController : ApiController
    {
        private LibraryContext db = new LibraryContext();

        // GET: api/Transaction
        public IQueryable<BookInfo> GetBookInfo()
        {
            return db.BookInfo;
        }

        // GET: check-out book
        public BookInfo CheckOut(int id)
        {
            BookInfo bookinfo = db.BookInfo.Find(id);
            if (bookinfo == null)
            {
                return null;
            }
            else
            {
                bookinfo.IsCheckedOut = true;
                bookinfo.LastCheckedOutDate = DateTime.Now;
                bookinfo.DueBackDate = DateTime.Now.AddDays(10);
            }
            return bookinfo;
        }

        //PUT: check-in book
        public BookInfo CheckIn(int id)
        {
            BookInfo bookinfo = db.BookInfo.Find(id);
            if (bookinfo == null)
            {
                return null;
            }
            else
            {
                bookinfo.IsCheckedOut = false;
                bookinfo.DueBackDate = null;
            }
            return bookinfo;
        }

        // POST: api/Transaction
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

        // DELETE: api/Transaction/5
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