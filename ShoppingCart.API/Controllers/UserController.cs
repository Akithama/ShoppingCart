using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShoppingCart.API.Helpers;
using ShoppingCart.Bll.Service;
using ShoppingCart.Bll.Service.Interface;
using ShoppingCart.Data.Infrastructure.Interfaces;
using ShoppingCart.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ShoppingCart.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly AppSettings appSettings;
        private readonly IUserRepository userRepository;
        private readonly IAddressRepository addressRepository;

        public UserController(IUserService userService, IUserRepository userRepository, IOptions<AppSettings> appSettings,
            IAddressRepository addressRepository)
        {
            this.userService = userService;
            this.userRepository = userRepository;
            this.appSettings = appSettings?.Value;
            this.addressRepository = addressRepository;
        }

        [AllowAnonymous]
        [HttpGet("Test")]
        public static IEnumerable<string> Get()
        {
            return new string[] { "API", "Working User Controller......" };
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateViewModel model)
        {
            if (model != null)
            {
                var user = userService.Authenticate(model.Username, model.Password);

                if (user == null)
                    return BadRequest("Username or password is incorrect");

                // return user info and token
                return Ok(new
                {
                    user.UserId,
                    Username = user.UserName,
                    user.FirstName,
                    user.LastName,
                    //Token = generateJwtToken(user.UserId,user.Email)
                    Token = userService.GenerateJwtToken(user.UserId.ToString(CultureInfo.InvariantCulture), user.Email, appSettings.Secret)
                });
            }
            else
                return BadRequest("Please provide user Information");
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserViewModel model)
        {
            if (model != null)
            {
                var user = userService.RegisterUser(model, model.Password);
                if (user != null)
                    return Ok(user);
                else
                {
                    return BadRequest(new { message = "Registration Unsucessfull." });
                }
            }
            else
                return BadRequest(new { message = "please provide information" });
        }

        [AllowAnonymous]
        [HttpGet("UserExists")]
        public ActionResult<IEnumerable<User>> Get(string userName)
        {
            //var user1 = userRepository.GetUserByName(userName);
            var user = userRepository.GetAll();
            if (user != null)
            {
                return user.ToList();
            }
            return null;
        }

        [AllowAnonymous]
        [HttpGet("user")]
        public ActionResult<UserViewModel> GetUpdateUser(int id)
        {
            var user = userRepository.GetById(id);
            if (user != null)
            {
                var address = addressRepository.GetById(user.UserId);

                UserViewModel uv = new UserViewModel()
                {
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    MobileNumber = user.MobileNumber,
                    Address1 = address.Address1,
                    Address2 = address.Address2,
                    Address3 = address.Address3
                };
                return uv;
            }
            return NotFound("User Not Found");
        }

        [AllowAnonymous]
        [HttpPut("UpdateUser")]
        public IActionResult UserUpdate([FromBody] UserUpdateViewModel model)
        {
            if (model != null)
            {
                var user = userService.UpdateUser(model);
                if (user != null)
                    return Ok(user);
                else
                {
                    return BadRequest(new { message = "Update Unsucessfull." });
                }
            }
            else
                return BadRequest(new { message = "please provide information" });
        }

        [AllowAnonymous]
        [HttpPut("RegisterCard")]
        public IActionResult RegisterNewCard([FromBody] CardDetail model)
        {
            if (model != null)
            {
                var user = userService.RegisterCard(model);
                if (user)
                    return Ok();
                else
                {
                    return BadRequest(new { message = "Update Unsucessfull." });
                }
            }
            else
                return BadRequest(new { message = "please provide information" });
        }
    }
}
