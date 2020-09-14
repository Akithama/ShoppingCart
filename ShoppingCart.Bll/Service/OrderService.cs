using ShoppingCart.Bll.Service.Interface;
using ShoppingCart.Bll.ViewModels;
using ShoppingCart.Data;
using ShoppingCart.Data.Infrastructure.Interfaces;
using ShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Bll.Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService emailService;

        public OrderService(IUnitOfWork unitOfWork, IEmailService emailService)
        {
            this._unitOfWork = unitOfWork;
            this.emailService = emailService;
        }

        public bool PlaceOrder(List<OrderViewModel> model, int userID, EmailSettings emailSettings)
        {
            if (model != null)
            {
                decimal total = model.Sum(item => item.Price * item.Items);
                Order order = new Order
                {
                    UserId = userID,
                    DateCreated = DateTime.Now,
                    DateShipped = DateTime.Now,
                    Status = "C",
                    TotalAmount = total
                };
                _unitOfWork.Order.Add(order);

                foreach (var item in model)
                {
                    OrderDetail orderDetail = new OrderDetail
                    {
                        Order = order,
                        ProductId = item.ProductID,
                        Quantity = item.Items,
                        Price = item.Price,
                        SubTotal = item.Items * item.Price
                    };

                    _unitOfWork.OrderDetail.Add(orderDetail);
                }
                _unitOfWork.Save();

                sendMail(model, userID, emailSettings);

                return true;
            }
            return false;
        }

        private void sendMail(List<OrderViewModel> model, int userID, EmailSettings emailSettings)
        {
            var user = _unitOfWork.User.GetById(userID);
            var shippingAddress = _unitOfWork.Address.GetById(user.UserId);
            string emailBody;

            emailBody = "<br><br><table border='1'>" +
            "<tr>" +
             "<th>Full Name</th>" +
             "<th>Address</th>" +
             "<th>Total</th>" +
            "</tr>" +
            "<tr>" +
             "<td>" + user.FirstName + " " + user.LastName + "</td>" +
             "<td>" + shippingAddress.Address1 + " " + shippingAddress.Address2 + " " + shippingAddress.Address3 + "</td>" +
             "<td>" + model.Sum(item => item.Price * item.Items) + "</td>" +
            "</tr>" +
            "</table><br><br>" + "Item Purchase";

            foreach (var item in model)
            {
                emailBody += "<table>" +
                 "<tr>" +
                 "<td>" + "Name: " + _unitOfWork.Product.GetById(item.ProductID).ProductName + "</td>" +
                 "<td>" + "Quantity: " + item.Items + "</td>" +
                 "<td>" + "Price: " + "$" + item.Price + "</td>" +
                 "</tr>" +
                 "</table>";
            }

            EmailViewModel viewModel = new EmailViewModel()
            {
                From = "shoppingCart@cart.com",
                Subject = "E - Bill",
                To = "dhananjaya_gw@yahoo.com",
                Body = emailBody
            };

            emailService.Send(viewModel, emailSettings);
        }
    }
}
