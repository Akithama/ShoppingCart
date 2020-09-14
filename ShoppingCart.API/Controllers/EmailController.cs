using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ShoppingCart.API.Helpers;
using ShoppingCart.Bll.Service.Interface;
using ShoppingCart.Bll.ViewModels;
using ShoppingCart.Data;

namespace ShoppingCart.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailSettings emailSettings;
        private readonly IEmailService emailService;

        public EmailController(IOptions<EmailSettings> emailSettings, IEmailService emailService)
        {
            this.emailSettings = emailSettings?.Value;
            this.emailService = emailService;
        }

        [HttpPost]
        public IActionResult SentMail(EmailViewModel model)
        {
            if(model!=null)
            {
                emailService.Send(model, emailSettings);
            }
            return BadRequest(new { message = "please provide information" });
        }

    }
}
