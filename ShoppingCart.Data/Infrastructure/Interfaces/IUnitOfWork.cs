using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Data.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {        
        IUserRepository User { get; }
        IAddressRepository Address { get; }
        ICategoryRepository Category { get; }
        IProductRepository Product { get; }
        ICardRepository Card { get; }
        IOrderRepository Order { get; }
        IOrderDetailRepository OrderDetail { get; }
        void Save();
    }
}
