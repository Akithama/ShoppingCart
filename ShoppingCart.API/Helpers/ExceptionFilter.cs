﻿using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //var result = new ViewResult { ViewName = "Error" };
            //var modelMetadata = new EmptyModelMetadataProvider();
            //result.ViewData = new ViewDataDictionary(modelMetadata, context.ModelState);
            //result.ViewData.Add("HandleException", context.Exception);
            //context.Result = result;
            //context.ExceptionHandled = true;
        }
    }
}