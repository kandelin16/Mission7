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
        public void SaveProduct(Books product)
        {
            _context.SaveChanges();
        }
        public void DeleteProduct(Books product)
        {
            _context.Remove(product);
            _context.SaveChanges();
        }
        public void CreateProduct(Books product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }
    }
}
