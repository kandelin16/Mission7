using Microsoft.AspNetCore.Mvc;
using Mission7.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IBookstoreRepository repo { get; set; }

        public TypesViewComponent(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.category = RouteData?.Values["category"];
            var types = repo.books.Select(x => x.Category).Distinct().OrderBy(x => x);
            return View(types);
        }
    }
}
