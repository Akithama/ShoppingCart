using ShoppingCart.Data.Infrastructure.Interfaces;
using ShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Infrastructure.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ShoppingCartContext context) : base(context) { }

        public List<Order> GetAllByUserID(int ID)
        {
            return Context.Order.Where(x => x.UserId == ID).ToList();
        }
    }
}
