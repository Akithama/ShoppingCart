using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingCart.API.Controllers;
using ShoppingCart.API.Helpers;
using ShoppingCart.Bll.Service;
using ShoppingCart.Bll.Service.Interface;
using ShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Test
{
    [TestClass]
    public class User_Login
    {
        AuthenticateViewModel model = new AuthenticateViewModel { Username = "Test", Password = "123" };

        User userModel = new User { UserId = 1, UserName = "Test", Email = "test@gmail.com" };

        [TestMethod]
        public void UserLoginReturnModel()
        {

            var apSettings = new Mock<IOptions<AppSettings>>();
            var logger = new Mock<ILogger<UserController>>();
            var userUservice = new Mock<IUserService>();

            //Act
            var controller = new UserController(logger.Object, userUservice.Object, apSettings.Object);            
            userUservice.Setup(x => x.Authenticate(model.Username, model.Password)).Returns(userModel);
            userUservice.Setup(x => x.GenerateJwtToken(userModel.UserId, userModel.Email)).Returns("");

            var result = controller.Authenticate(model);


            //Assert
            Assert.IsNotNull(result);
           Assert.IsInstanceOfType(result,typeof(OkObjectResult));
        }

    }
}
