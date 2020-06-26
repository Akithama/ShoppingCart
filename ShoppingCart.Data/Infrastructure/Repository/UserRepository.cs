using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Infrastructure.Interfaces;
using ShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Infrastructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ShoppingCartContext context) : base(context) { }

        public Task<User> GetByName(string username)
        {
            return context.Set<User>().FirstOrDefaultAsync(User => User.UserName == username);
        }
    }
}
