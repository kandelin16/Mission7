using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models.ViewModels
{
    public class PageInfo
    {
        public int TotalBooks { get; set; }
        public int BooksPerPage { get; set; }
        public int PageNum { get; set; }
        public int NumberOfPages => ((TotalBooks / BooksPerPage) + 1);
    }
}
