using ShoppingCart.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Data.Infrastructure.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        List<Product> GetProductsByCategoryId(int categoryId); //IEnumerable

        //IEnumerable GetProductsByCategoryId(int categoryId);

    }
}
