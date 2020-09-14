using ShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Bll.Service.Interface
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        UserViewModel RegisterUser(UserViewModel user, string password);
        UserUpdateViewModel UpdateUser(UserUpdateViewModel user);
        string GenerateJwtToken(string customerId, string email,string secret);
        CardDetail UpdateCard(CardDetail model);
        bool RegisterCard(CardDetail model);
    }
}
