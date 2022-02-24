using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public class Cart
    {
        public List<CartItem> cartItems { get; set; } = new List<CartItem>();
        public void AddItem(Books book, int quantity)
        {
            CartItem tempItem = cartItems.Where(b => b.book.BookId == book.BookId).FirstOrDefault();

            if (tempItem == null)
            {
                cartItems.Add(new CartItem
                {
                    book = book,
                    Quantity = quantity
                });
            }
            else
            {
                tempItem.Quantity += quantity;
            }
        }
        public double CalculateTotal()
        {
            double sum = cartItems.Sum(x => x.Quantity * x.book.Price);
            return sum;
        }
    }
    public class CartItem
    {
        public int LineID { get; set; }
        public Books book { get; set; }
        public int Quantity { get; set; }

    }
}
