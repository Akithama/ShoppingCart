using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShoppingCart.API.Helpers
{
    /// <summary>
    /// Need to implement this one.no idea how to intergrate this
    /// </summary>
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context != null)
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var exception = context.Exception;
                context.Result = new JsonResult(exception.Message);
            }
        }
    }
}
