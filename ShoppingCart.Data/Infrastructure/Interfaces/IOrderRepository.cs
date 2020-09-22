using ShoppingCart.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Data.Infrastructure.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<Order> GetAllByUserID(int ID);
    }
}
