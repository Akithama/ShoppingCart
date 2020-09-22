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
using ShoppingCart.Data.Models;
using ShoppingCart.Data.Infrastructure.Interfaces;

namespace ShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly EmailSettings emailSettings;
        private IOrderRepository orderRepository;
        private IOrderDetailRepository orderDetailRepository;

        public OrderController(IOrderService orderService, IOptions<EmailSettings> emailSettings,
            IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            this.orderService = orderService;
            this.emailSettings = emailSettings?.Value;
            this.orderRepository = orderRepository;
            this.orderDetailRepository = orderDetailRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult PlaceOrder([FromBody] List<OrderViewModel> model, int userID)
        {
            if (model != null)
            {
                var result = orderService.PlaceOrder(model, userID, emailSettings);
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

        [HttpGet]
        public ActionResult<IEnumerable<OrderHistoryViewModel>> GetOrderList(int userID)
        {
            var orderHistory = orderService.GetOrderHistory(userID);

            if (orderHistory.Count != 0)
                return orderHistory;

            return NotFound("Orders Not Found");
        }

        [HttpGet("Detail")]
        public ActionResult<IEnumerable<OrderDetailHistoryViewModel>> GetOrderDetail(int orderID)
        {
            var orderDetailHistory = orderService.GetOrderDetailHistory(orderID);

            if (orderDetailHistory.Count != 0)
                return orderDetailHistory;

            return NotFound("Orders Not Found");
        }
    }
}
