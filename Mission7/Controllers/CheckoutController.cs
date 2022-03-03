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
        public CheckoutController(IOrderRepository temp, Cart tempCart)
        {
            _repo = temp;
            _cart = tempCart;
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Order());
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (_cart.cartItems.Count() == 0)
            {
                ModelState.AddModelError("", "Your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                order.Items = _cart.cartItems.ToArray();
                _repo.SaveOrder(order);
                _cart.ClearCart();

                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
