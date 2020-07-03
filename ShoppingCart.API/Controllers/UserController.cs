using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ShoppingCart.API.Helpers;
using ShoppingCart.API.ViewModels;
using ShoppingCart.Data.Models;
using ShoppingCart.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShoppingCart.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        private IMapper mapper;
        private readonly AppSettings appSettings;
        private readonly ILogger logger;

        public UserController(ILogger<UserController> _logger, IUserService _userService, IMapper _mapper,
            IOptions<AppSettings> _appSettings)
        {
            userService = _userService;
            appSettings = _appSettings.Value;
            mapper = _mapper;
            logger = _logger;
        }

        [AllowAnonymous]
        [HttpGet("Test")]
        public IEnumerable<string> Get()
        {
            logger.LogInformation("Start : API Working Log...");
            return new string[] { "API", "Working User Controller......" };
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateViewModel model)
        {
            var user = userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });
                        
            // return user info and token
            return Ok(new
            {
                Id = user.CustomerId,
                Username = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = generateJwtToken(user.CustomerId,user.Email)
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] CustomerViewModel model)
        {
            var customer = mapper.Map<Customer>(model);

            try
            {
                userService.RegisterCustomer(customer, model.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError("Error : ", ex.Message);
                return BadRequest(new { message = ex.Message });                
            }
        }

        private string generateJwtToken(int customerId, string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, customerId.ToString()),
                    new Claim(ClaimTypes.Email, email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
