using LojaQualquer.WebApi.Domain.Models;
using LojaQualquer.WebApi.Domain.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace LojaQualquer.WebApi.Configuration
{
    public class HttpResponseExceptionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is BusinessException)
            {
                context.Result = new ObjectResult(new ResponseError
                {
                    Message = context.Exception.Message
                })
                {
                    StatusCode = 400
                };

                context.ExceptionHandled = true;
            }
            else if (context.Exception is Exception)
            {
                context.Result = new ObjectResult(new ResponseError
                {
                    Message = "Internal Server Error"
                })
                {
                    StatusCode = 500
                };

                context.ExceptionHandled = true;
            }
        }
    }
}