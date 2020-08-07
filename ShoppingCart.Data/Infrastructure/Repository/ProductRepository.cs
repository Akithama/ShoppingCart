using ShoppingCart.Data.Infrastructure.Interfaces;
using ShoppingCart.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Infrastructure.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ShoppingCartContext context) : base(context) { }

        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            return Context.Product.Where(x => x.CategoryId == categoryId).ToList();
        }
    }
}
