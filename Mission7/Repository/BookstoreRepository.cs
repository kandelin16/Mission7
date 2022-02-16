using Mission7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Repository
{
    public class BookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext _context { get; set; }
        public BookstoreRepository(BookstoreContext temp)
        {
            _context = temp;
        }
        public IQueryable<Books> books => _context.Books;
    }
}
