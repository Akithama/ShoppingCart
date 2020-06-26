using ShoppingCart.Data.Models;

namespace ShoppingCart.Data.Services.Interfaces
{
    public interface IUserService
    {
        Customer Authenticate(string username, string password);
        Customer RegisterCustomer(Customer customer,string password);
    }
}
