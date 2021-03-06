﻿using Microsoft.IdentityModel.Tokens;
using ShoppingCart.Bll.Service.Interface;
using ShoppingCart.Data.Infrastructure.Interfaces;
using ShoppingCart.Data.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ShoppingCart.Bll.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            //var user = _context.User.SingleOrDefault(x => x.UserName == username);
            var user = _unitOfWork.User.GetUserByName(username);

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
            if (userVM != null)
            {
                // validation
                if (string.IsNullOrWhiteSpace(password))
                    throw new Exception("Password is required");

                if (_unitOfWork.User.UserExists(userVM.UserName))
                    throw new Exception("Username \"" + userVM.UserName + "\" is already taken");

                if (_unitOfWork.User.UserEmailExists(userVM.Email))
                    throw new Exception("E-Mail \"" + userVM.Email + "\" is already taken");

                //CreatePasswordHash(password, out passwordHash, out passwordSalt);
                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

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

                _unitOfWork.User.Add(user);

                Address address = new Address
                {
                    Address1 = userVM.Address1,
                    Address2 = userVM.Address2,
                    Address3 = userVM.Address3,
                    IsDelivery = true,
                    User = user
                };

                _unitOfWork.Address.Add(address);

                _unitOfWork.Save();

                return userVM;
            }
            else
            {
                throw new ArgumentNullException(nameof(password));
            }
        }

        public UserUpdateViewModel UpdateUser(UserUpdateViewModel userVM)
        {
            if (userVM != null)
            {
                var user = _unitOfWork.User.GetById(userVM.UserId);
                if (user != null)
                {
                    user.FirstName = userVM.FirstName;
                    user.LastName = userVM.LastName;
                    user.MobileNumber = userVM.MobileNumber;

                    _unitOfWork.User.Update(user);
                    _unitOfWork.Save();

                    var address = _unitOfWork.Address.GetById(userVM.UserId);
                    if (address != null)
                    {
                        address.Address1 = userVM.Address1;
                        address.Address2 = userVM.Address2;
                        address.Address3 = userVM.Address3;
                        _unitOfWork.Address.Update(address);
                        _unitOfWork.Save();
                    }
                }
            }
            return userVM;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));
            if (storedHash.Length != 64)
            {
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            }

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

        public string GenerateJwtToken(string customerId, string email, string secret)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, customerId),
                    new Claim(ClaimTypes.Email, email?.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public CardDetail UpdateCard(CardDetail model)
        {
            if (model != null)
            {
                var card =_unitOfWork.Card.GetById(model.CardNumber);
                if (card != null)
                {
                    //hold no need update........
                }
            }
            throw new NotImplementedException();
        }

        public bool RegisterCard(CardDetail model)
        {
            if (model != null)
            {
                _unitOfWork.Card.Add(model);
                _unitOfWork.Save();
                return true;
            }

            return false;
        }
    }
}
