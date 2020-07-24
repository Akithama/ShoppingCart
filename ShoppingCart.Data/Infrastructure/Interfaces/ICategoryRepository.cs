using ShoppingCart.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Infrastructure.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        //IEnumerable GetCategoryAll();

        //Task<Category> GetByName(string firstName);
    }
}
