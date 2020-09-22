using ShoppingCart.Data.Infrastructure.Interfaces;
using ShoppingCart.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Infrastructure.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(ShoppingCartContext context) : base(context) { }

        public List<OrderDetail> GetAllByOrderID(int ID)
        {
            return Context.OrderDetail.Where(x => x.OrderId == ID).ToList();            
        }
    }
}
