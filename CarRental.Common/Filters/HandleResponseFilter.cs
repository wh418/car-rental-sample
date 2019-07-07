using System.Linq;
using CarRental.Common.Foundation.Responses;
using CarRental.Common.Foundation.Responses.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using CarRental.Common.Validation.Responses;

namespace CarRental.Common.Filters
{
	public class HandleResponseFilter : IResultFilter, IActionFilter
    {
		public void OnResultExecuting(ResultExecutingContext context)
		{
			var objectResult = context.Result as ObjectResult;

		    if (!(objectResult?.Value is IResponse response))
				return;

			if (!response.IsSuccessful)
			{
				var errorResponse = new StandardResponse(response);

				context.HttpContext.Response.StatusCode = (int)response.Status.GetHttpStatusCode();
				context.Result = new ObjectResult(errorResponse);
			    return;
			}
		    if (response is IResponse<dynamic> resultResponse)
		    {
                context.HttpContext.Response.StatusCode = (int)response.Status.GetHttpStatusCode();
		        context.Result = new ObjectResult(resultResponse.Result);
            }
		}


        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var response = new ValidationResponse
                {
                    Errors = context.ModelState.Keys
                        .SelectMany(key =>
                            context.ModelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                        .ToList()
                };
                context.HttpContext.Response.StatusCode = (int)response.Status.GetHttpStatusCode();
                context.Result = new ObjectResult(response);
            }
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
