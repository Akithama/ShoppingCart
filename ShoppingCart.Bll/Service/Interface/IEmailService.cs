using ShoppingCart.Bll.ViewModels;
using ShoppingCart.Data;

namespace ShoppingCart.Bll.Service.Interface
{
    public interface IEmailService
    {
        void Send(EmailViewModel model, EmailSettings emailSettings);
    }
}
