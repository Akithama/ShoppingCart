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
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ShoppingCart.API.Controllers
{
    [Authorize]
    [ApiController]    
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;        
        private readonly AppSettings appSettings;
        private readonly IUserRepository userRepository;

        public UserController(IUserService userService, IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            this.userService = userService;
            this.userRepository = userRepository;
            this.appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpGet("Test")]
        public IEnumerable<string> Get()
        {
            return new string[] { "API", "Working User Controller......" };
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateViewModel model)
        {
            if (model!=null)
            {
                var user = userService.Authenticate(model.Username, model.Password);

                if (user == null)
                    return BadRequest("Username or password is incorrect");

                // return user info and token
                return Ok(new
                {
                    Id = user.UserId,
                    Username = user.UserName,
                    user.FirstName,
                    user.LastName,
                    //Token = generateJwtToken(user.UserId,user.Email)
                    Token = userService.GenerateJwtToken(user.UserId, user.Email, appSettings.Secret)
                }); 
            }
            else
                return BadRequest("Please provide user Information");
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserViewModel model)
        {
            if (model!=null)
            {
                var user = userService.RegisterUser(model, model.Password);
                if (user != null)
                    return Ok(user);
                else
                {
                    return BadRequest(new { message = "Registration Unsucessfull." });
                } 
            }else
                return BadRequest(new { message = "please provide information" });
        }

        [AllowAnonymous]
        [HttpGet("UserExists")]
        public ActionResult<IEnumerable<User>> Get(string userName)
        {
            var user = userRepository.GetAll();
            if (user != null)
            {
                return user.ToList();
            }
            return null;
        }
    }
}
