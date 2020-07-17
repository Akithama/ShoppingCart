using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ShoppingCart.API.Helpers
{
    public class TestFilter : ExceptionFilterAttribute
    {
        //public override void OnException(ExceptionContext context)
        //{
        //    var exception = context.Exception;
        //    context.Result = new JsonResult(exception.Message);
        //}
    }
}
