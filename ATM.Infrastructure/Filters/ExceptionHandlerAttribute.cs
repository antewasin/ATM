using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ATM.Infrastructure.Filters
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            
            var result = new JsonResult(exception.Message);

            result.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Result = result;

        }


    }
}
