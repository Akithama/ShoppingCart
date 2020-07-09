using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingCart.API.Controllers;
using ShoppingCart.API.Helpers;
using ShoppingCart.Bll.Service;
using ShoppingCart.Bll.Service.Interface;

namespace ShoppingCart.Test
{
    [TestClass]
    public class User_Test
    {
        [TestMethod]
        public void UserRegister_Test()
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

            //Act
            var controller = new UserController(logger.Object, userUservice.Object, apSettings.Object);
            userUservice.Setup(x => x.RegisterUser(model, "password")).Returns(model);
            var result = controller.Register(model);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}
