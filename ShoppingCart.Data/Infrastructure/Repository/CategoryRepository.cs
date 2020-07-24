using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Infrastructure.Interfaces;
using ShoppingCart.Data.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Infrastructure.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ShoppingCartContext context) : base(context) { }

        //public IEnumerable GetCategoryAll()
        //{
        //    return context.Set<Category>().ToList();
        //}

        //public Task<Category> GetByName(string name)
        //{
        //    return Context.Set<Category>().FirstOrDefaultAsync(x => x.CategoryName == name);
        //    // return FirstOrDefault(author => author.Name == name);
        //}
    }
}
