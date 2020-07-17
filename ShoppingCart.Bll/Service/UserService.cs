﻿using ShoppingCart.Bll.Service.Interface;
using ShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Bll.Service
{
    public class UserService : IUserService
    {
        private ShoppingCartContext _context;

        public UserService(ShoppingCartContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.User.SingleOrDefault(x => x.UserName == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public UserViewModel RegisterUser(UserViewModel userVM, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");

            if (_context.User.Any(x => x.UserName == userVM.UserName))
                throw new Exception("Username \"" + userVM.UserName + "\" is already taken");

            if (_context.User.Any(x => x.Email == userVM.Email))
                throw new Exception("E-Mail \"" + userVM.Email + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            User user = new User
            {
                UserName = userVM.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                DateRegister = DateTime.Now,
                Email = userVM.Email,
                FirstName = userVM.FirstName,
                LastName = userVM.LastName,
                IsAdmin = false,
                MobileNumber = userVM.MobileNumber
            };

            _context.User.Add(user);
            

            Address address = new Address
            {
                Address1 = userVM.Address1,
                Address2 = userVM.Address2,
                Address3 = userVM.Address3,
                IsDelivery = true,
                User = user
            };

            _context.Address.Add(address);

            _context.SaveChanges();

            return userVM;

        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

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
