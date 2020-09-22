using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingCart.Bll.Service.Interface;
using ShoppingCart.Bll.ViewModels;
using ShoppingCart.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Test
{
    [TestClass]
    public class Order
    {
        [TestMethod]
        public void UserRegister_Post_GetResult()
        {
            //Arrange
            OrderHistoryViewModel orderHistory = new OrderHistoryViewModel
            {
                CustomerName = "",
                DateAdded = DateTime.Now.ToString(),
                NoOfProducts = 5,
                OrderID = 1,
                Status = "C",
                Total = 1250
            };
            var orderService = new Mock<IOrderService>();
            var emailSettings = new Mock<EmailSettings>();


        //    //Act
        //    var controller = new UserController(userUservice.Object, userRepo.Object, apSettings.Object, addressRepo.Object);
        //    orderService.Setup(x => x.RegisterUser(model, model.Password)).Returns(orderHistory);
        //    var result = controller.Register(model);

        //    //Assert
        //    Assert.IsNotNull(result);
        //    Assert.AreEqual(200, (result as OkObjectResult).StatusCode);
        }
    }
}
