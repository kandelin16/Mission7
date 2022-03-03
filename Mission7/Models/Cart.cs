using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public class Cart
    {
        public List<CartItem> cartItems { get; set; } = new List<CartItem>();
        public virtual void AddItem(Books book, int quantity)
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
        public virtual void RemoveItem(Books book)
        {
            cartItems.RemoveAll(x => x.book.BookId == book.BookId);
        }
        public virtual void ClearCart()
        {
            cartItems.Clear();
        }
        public double CalculateTotal()
        {
            double sum = cartItems.Sum(x => x.Quantity * x.book.Price);
            return sum;
        }
    }
    public class CartItem
    {
        [Key]
        public int LineID { get; set; }
        public Books book { get; set; }
        public int Quantity { get; set; }

    }
}
