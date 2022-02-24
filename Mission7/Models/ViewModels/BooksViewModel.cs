using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models.ViewModels
{
    public class BooksViewModel
    {
        public IQueryable<Books> books { get; set; }
        public PageInfo pageInfo { get; set; }
    }
}
