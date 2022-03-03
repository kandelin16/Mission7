using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission7.Models;
using Mission7.Repository;

namespace Mission7.Controllers
{
    public class CheckoutController : Controller
    {
        private IOrderRepository _repo { get; set; }
        private Cart _cart { get; set; }
        
        //Sets the repository and cart objects when the controller is instantiated.
        public CheckoutController(IOrderRepository temp, Cart tempCart)
        {
            _repo = temp;
            _cart = tempCart;
        }

        //For rendering the Checkout page
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Order());
        }

        //For submitting the checkout page when the user has filled out the form
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (_cart.cartItems.Count() == 0) //Checks if the cart has items in it.
            {
                ModelState.AddModelError("", "Your cart is empty!");
            }
            if (ModelState.IsValid) //Checks the form then saves the order and goes to the confirmation page.
            {
                order.Items = _cart.cartItems.ToArray();
                _repo.SaveOrder(order);
                _cart.ClearCart();

                return RedirectToPage("/OrderConfirmation");
            }
            else
            {
                return View();
            }
        }
    }
}
