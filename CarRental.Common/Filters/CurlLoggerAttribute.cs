using System;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace CarRental.Common.Filters
{
    public class CurlLoggerAttribute : TypeFilterAttribute
    {
        public CurlLoggerAttribute() : base(typeof(AutoLogActionFilterImpl)) { }
        private class AutoLogActionFilterImpl : IActionFilter
        {
            public AutoLogActionFilterImpl(ILoggerFactory loggerFactory) { }
            public void OnActionExecuted(ActionExecutedContext context) { }
            public void OnActionExecuting(ActionExecutingContext context)
            {
                var request = context.HttpContext.Request;
                StringBuilder curl = new StringBuilder("curl " + request.Scheme + "://" + request.Host + request.Path);
                curl.Append(" -X " + request.Method);
                var authorizationHeader = request.Headers["Authorization"];
                if (authorizationHeader.Any())
                    curl.Append(" -H 'Authorization: " + authorizationHeader[0] + "'");

                if (request.Body.CanSeek)
                {
                    request.Body.Position = 0;
                    using (StreamReader reader = new StreamReader(request.Body))
                        curl.Append(" --data '" + reader.ReadToEnd() + "'");
                }

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(curl.ToString());
                Console.ResetColor();
            }

        }
    }
}