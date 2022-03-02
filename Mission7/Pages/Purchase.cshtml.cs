using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission7.Models;
using Mission7.Repository;
using Mission7.Struct;

namespace Mission7.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBookstoreRepository _repo { get; set; }
        public PurchaseModel(IBookstoreRepository repo, Cart tempcart)
        {
            _repo = repo;
            cart = tempcart;
        }
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(int bookID, int quantity, string returnUrl)
        {
            Books b = _repo.books.FirstOrDefault(x => x.BookId == bookID);

            cart.AddItem(b, 1);
            
            return RedirectToPage(new { returnUrl = returnUrl});
        }
        public IActionResult OnPostMalone(int BookId, string returnURL)
        {
            cart.RemoveItem(cart.cartItems.First(b => b.book.BookId == BookId).book);
            return RedirectToPage(new { returnURL = returnURL });
        }
    }
}
