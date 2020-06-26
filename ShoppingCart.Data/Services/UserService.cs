using Microsoft.Extensions.Options;
using ShoppingCart.Data.Models;
using ShoppingCart.Data.Services.Interfaces;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ShoppingCart.Data.Services
{
    public class UserService : IUserService
    {
        private ShoppingCartContext _context;

        public UserService(ShoppingCartContext context)
        {
            _context = context;
        }

        public Customer Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Customer.SingleOrDefault(x => x.UserName == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public Customer RegisterCustomer(Customer customer, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new NotImplementedException();

            if (_context.Customer.Any(x => x.UserName == customer.UserName))
                throw new NotImplementedException();

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            customer.PasswordHash = passwordHash;
            customer.PasswordSalt = passwordSalt;
            customer.DateRegister = DateTime.Now;

            _context.Customer.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new NotImplementedException();
            if (string.IsNullOrWhiteSpace(password)) throw new NotImplementedException();

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
