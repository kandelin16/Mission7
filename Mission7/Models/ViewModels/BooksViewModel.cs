using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models.ViewModels
{
    public class BooksViewModel
    {
        //This model contains a list of books as well as a pageinfo object. This is passed to the index page to render the main list of books.
        public IQueryable<Books> books { get; set; }
        public PageInfo pageInfo { get; set; }
    }
}
