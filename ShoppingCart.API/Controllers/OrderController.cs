using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Bll.Service.Interface;
using ShoppingCart.Bll.ViewModels;
using Microsoft.Extensions.Options;
using ShoppingCart.Data;

namespace ShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly EmailSettings emailSettings;

        public OrderController(IOrderService orderService,IOptions<EmailSettings> emailSettings)
        {
            this.orderService = orderService;
            this.emailSettings = emailSettings?.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult PlaceOrder([FromBody] List<OrderViewModel> model,int userID)
        {
            if (model != null)
            {
                var result=orderService.PlaceOrder(model, userID, emailSettings);
                if (result)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest(new { message = "Order place faild" });
                }                    
            }
            return BadRequest(new { message = "Order Processing faild" });
        }
    }
}
