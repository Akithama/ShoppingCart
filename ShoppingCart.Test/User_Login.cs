using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingCart.API.Controllers;
using ShoppingCart.API.Helpers;
using ShoppingCart.Bll.Service;
using ShoppingCart.Bll.Service.Interface;
using ShoppingCart.Data.Infrastructure.Interfaces;
using ShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Test
{
    [TestClass]
    public class User_Login
    {
        readonly AuthenticateViewModel model = new AuthenticateViewModel { Username = "Test", Password = "123" };
        readonly User userModel = new User { UserId = 1, UserName = "Test", Email = "test@gmail.com" };

        [TestMethod]
        public void UserLoginReturnModel()
        {
            var settings = new AppSettings() { Secret = "Secret" };
            IOptions<AppSettings> apSettings = Options.Create(settings);
            var logger = new Mock<ILogger<UserController>>();
            var userUservice = new Mock<IUserService>();
            var userRepo = new Mock<IUserRepository>();
            
            //Act
            var controller = new UserController(userUservice.Object, userRepo.Object, apSettings);
            userUservice.Setup(x => x.Authenticate(model.Username, model.Password)).Returns(userModel);
            userUservice.Setup(x => x.GenerateJwtToken(userModel.UserId, userModel.Email, apSettings.Value.Secret)).Returns("");

            var result = controller.Authenticate(model);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

    }
}
