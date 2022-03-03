using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission7.Models;

namespace Mission7.Repository
{
    public interface IOrderRepository
    {
        IQueryable<Order> orders { get; }
        void SaveOrder(Order order);
    }
}
