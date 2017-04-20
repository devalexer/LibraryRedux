using LibraryRedux.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryRedux.DataContext
{
    public class LibraryContext :DbContext
    {
        public LibraryContext():base("name=DefaultConnection")
        {

        }

        public DbSet<BookInfo> BookInfo { get; set; }
        public DbSet<PatronInfo> PatronInfo { get; set; }
    }
}