using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Infrastructure.Interfaces;
using ShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Infrastructure.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected ShoppingCartContext Context { get; set; }

        public Repository(ShoppingCartContext _Context)
        {
            this.Context = _Context;
        }
        public void Delete(object id)
        {
            var entity = Context.Set<T>().Find(id);
            Context.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return this.Context.Set<T>().ToList();
        }

        public T GetById(object id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Add(T obj)
        {
            Context.Set<T>().Add(obj);
        }

        public void Update(T obj)
        {
            this.Context.Entry(obj).State = EntityState.Modified;
        }
    }
}
