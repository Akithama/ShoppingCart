using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Data.Infrastructure.Interfaces
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Add(T obj);
        void Update(T obj);
        void Delete(object id);
    }
}
