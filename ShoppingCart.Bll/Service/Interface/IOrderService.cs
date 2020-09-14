using ShoppingCart.Bll.ViewModels;
using ShoppingCart.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Bll.Service.Interface
{
    public interface IOrderService
    {
        bool PlaceOrder(List<OrderViewModel> model, int userID, EmailSettings emailSettings);
    }
}
