using ShoppingCart.Data.Infrastructure.Interfaces;
using ShoppingCart.Data.Models;

namespace ShoppingCart.Data.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoppingCartContext _context;
        private ICategoryRepository _category;
        private IUserRepository _user;
        private IAddressRepository _address;

        public UnitOfWork(ShoppingCartContext context)
        {
            _context = context;
        }

        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_context);
                }

                return _category;
            }
        }
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_context);
                }

                return _user;
            }
        }        
        public IAddressRepository Address
        {
            get
            {
                if (_address == null)
                {
                    _address = new AddressRepository(_context);
                }
                return _address;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
