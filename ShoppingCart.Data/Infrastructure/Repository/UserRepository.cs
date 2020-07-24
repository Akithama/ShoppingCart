using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Infrastructure.Interfaces;
using ShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Infrastructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ShoppingCartContext Context) : base(Context) { }

        public bool UserEmailExists(string email)
        {
            return Context.Set<User>().Any(x => x.Email == email);
        }

        public User GetUserByName(string username)
        {
            return Context.Set<User>().FirstOrDefault(User => User.UserName == username);
        }

        public bool UserExists(string username)
        {
            return Context.Set<User>().Any(x => x.UserName == username);
        }
    }
}
