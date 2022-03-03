using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission7.Models;
using Mission7.Models.ViewModels;
using Mission7.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Controllers
{
    public class HomeController : Controller
    {
        private  ILogger<HomeController> _logger;
        private IBookstoreRepository _repo { get; }

        //When the home controller is instantiated, sets the logger and repo equal to new instances of those objects.
        public HomeController(ILogger<HomeController> logger, IBookstoreRepository temp)
        {
            _logger = logger;
            _repo = temp;
        }

        //For the index page we take a list of all of the books where the category matches according to the page number.
        public IActionResult Index(string category="", int pageNum = 1)
        {
            BooksViewModel view = new BooksViewModel(); //The books view model will have the list of all of the books as well as a PageInfo object.
            view.books = _repo.books.Where(p => p.Category == category || category == "").OrderBy(p => p.Title).Skip((pageNum - 1) * 10).Take(10);
            var x = new PageInfo() //The page info class contains a count of the boks, books per page, and page number
            {
                TotalBooks = category == "" ? _repo.books.Count() : _repo.books.Where(b => b.Category == category).Count(),
                BooksPerPage = 10,
                PageNum = pageNum
            };
            view.pageInfo = x;

            return View(view);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
