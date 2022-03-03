using Microsoft.EntityFrameworkCore;
using Mission7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private BookstoreContext _context { get; set; }

        public OrderRepository(BookstoreContext temp)
        {
            _context = temp;
        }

        //Queryable of all the orders
        IQueryable<Order> IOrderRepository.orders => _context.Orders.Include(x=> x.Items).ThenInclude(x => x.book);

        //Method for saving a completed order
        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.Items.Select(x => x.book));

            if (order.OrderID == 0)
            {
                _context.Orders.Add(order);
            }
            _context.SaveChanges();
        }
    }
}
