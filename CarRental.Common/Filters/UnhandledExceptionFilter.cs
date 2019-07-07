using System.Net;
using CarRental.Common.Exceptions;
using CarRental.Common.Extensions;
using CarRental.Common.Foundation.Responses;
using CarRental.Common.Foundation.Responses.Types;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace CarRental.Common.Filters
{
    public class UnhandledExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ILogger _logger;

        public UnhandledExceptionFilter(IHostingEnvironment hostingEnvironment, ILogger<UnhandledExceptionFilter> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (TryHandleException(context))
            {
                return;
            }

            var errorMessage = $"Unhandled Exception. Action: {context.ActionDescriptor.DisplayName} Url: {context.HttpContext.Request.GetAbsoluteUri()}, Method: {context.HttpContext.Request.Method}";

            _logger.LogError(context.Exception, errorMessage);


            if (_hostingEnvironment.IsDevelopment())
            {
                context.ExceptionHandled = true;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = new ObjectResult(new
                {
                    Exception = context.Exception.ToString(),
                    Action = context.ActionDescriptor.DisplayName,
                    Url = context.HttpContext.Request.GetAbsoluteUri(),
                    Method = context.HttpContext.Request.Method
                });
            }
        }

        private bool TryHandleException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case NotFoundException _:
                    context.ExceptionHandled = true;
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    context.Result = new ObjectResult(new StandardResponse(ResponseType.NotFound()));
                    return true;
                case UnauthorizedException _:
                    context.ExceptionHandled = true;
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Result = new ObjectResult(new StandardResponse(ResponseType.Unauthorised()));
                    return true;
                case ValidationException exception:
                    context.ExceptionHandled = true;
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    context.Result = new ObjectResult(new StandardResponse(ResponseStatus.Invalid, exception.Message, exception.Errors));
                    return true;
            }
            return false;
        }
    }
}