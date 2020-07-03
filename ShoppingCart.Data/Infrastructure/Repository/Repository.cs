﻿using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Infrastructure.Interfaces;
using ShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ShoppingCartContext context { get; set; }

        public Repository(ShoppingCartContext _Context)
        {
            this.context = _Context;
        }
        public void Delete(object id)
        {
            //this.context.Set<T>().Remove(id);

            var entity = context.Set<T>().Find(id);
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return this.context.Set<T>().ToList();
        }

        public T GetById(object id)
        {
            return context.Set<T>().Find(id);
        }

        public void Add(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChangesAsync();
        }

        public void Update(T obj)
        {
            this.context.Entry(obj).State = EntityState.Modified;
            context.SaveChangesAsync();
        }
    }
}