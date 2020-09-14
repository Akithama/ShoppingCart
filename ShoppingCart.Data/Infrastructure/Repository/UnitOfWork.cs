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
        private IProductRepository _product;
        private ICardRepository _card;
        private IOrderRepository _order;
        private IOrderDetailRepository _orderDetail;

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
        public IProductRepository Product
        {
            get
            {
                if (_product == null)
                {
                    _product = new ProductRepository(_context);
                }
                return _product;
            }
        }
        public ICardRepository Card
        {
            get
            {
                if (_card == null)
                {
                    _card = new CardRepository(_context);
                }
                return _card;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (_order == null)
                {
                    _order = new OrderRepository(_context);
                }
                return _order;
            }
        }

        public IOrderDetailRepository OrderDetail
        {
            get
            {
                if (_orderDetail == null)
                {
                    _orderDetail = new OrderDetailRepository(_context);
                }
                return _orderDetail;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
