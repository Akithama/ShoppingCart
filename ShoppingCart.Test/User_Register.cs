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
using System.Net;

namespace ShoppingCart.Test
{
    [TestClass]
    public class User_Register
    {
        [TestMethod]
        public void UserRegister_Post_GetResult()
        {
            //Arrange
            UserViewModel model = new UserViewModel
            {
                UserName = "Test",
                Password = "123",
                FirstName = "Test",
                LastName = "Test",
                Email = "Test@mail.com",
                MobileNumber = "000000000",
                Address1 = "Add1",
                Address2 = "Add1",
                Address3 = "Add1"
            };
            var apSettings = new Mock<IOptions<AppSettings>>();
            var logger = new Mock<ILogger<UserController>>();
            var userUservice = new Mock<IUserService>();
            var userRepo = new Mock<IUserRepository>();

            //Act
            var controller = new UserController(userUservice.Object, userRepo.Object, apSettings.Object);
            userUservice.Setup(x => x.RegisterUser(model, model.Password)).Returns(model);
            var result = controller.Register(model);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, (result as OkObjectResult).StatusCode);
        }

        [TestMethod]
        public void UserRegister_Username_AlreadyExists()
        {
            //Arrange
            UserViewModel model = new UserViewModel
            {
                UserName = "Test",
                Password = "",
                FirstName = "Test",
                LastName = "Test",
                Email = "Test@mail.com",
                MobileNumber = "000000000",
                Address1 = "Add1",
                Address2 = "Add1",
                Address3 = "Add1"
            };
            var apSettings = new Mock<IOptions<AppSettings>>();
            var logger = new Mock<ILogger<UserController>>();
            var userUservice = new Mock<IUserService>();
            var userRepo = new Mock<IUserRepository>();

            //Act
            var controller = new UserController(userUservice.Object, userRepo.Object, apSettings.Object);
            //userUservice.Setup(x => x.RegisterUser(model, model.Password)).Returns(model);
            var result = controller.Register(model);

            //Assert
            Assert.IsNotNull(result);

            //var usr = new UserService()
        }


        //[TestMethod]
        //public void CreateInvalidContact()
        //{
        //    // Arrange
        //    var contact = new Contact();
        //    _service.Expect(s => s.CreateContact(contact)).Returns(false);
        //    var controller = new ContactController(_service.Object);

        //    // Act
        //    var result = (ViewResult)controller.Create(contact);

        //    // Assert
        //    Assert.AreEqual("Create", result.ViewName);
        //}
    }
}
