using CarRental.Common.Foundation.Responses.Types;
using CarRental.Common.Validation.Responses;

namespace CarRental.Common.Foundation.Responses
{
    public static class ResponseType
    {
        public static readonly IResponse Success = new Response { Status = ResponseStatus.Success };

        public static IResponse NotFound(string error = null)
        {
            return new NotFoundResponse { Message = error };
        }

        public static IResponse<T> NotFound<T>(string error = null)
        {
            return new NotFoundResponse<T> { Message = error };
        }

        public static IResponse Invalid(string invalidMessage)
        {
            return new ValidationResponse { Errors = new[] { new ValidationError(null, invalidMessage) } };
        }

        public static IResponse Invalid(string field, string invalidMessage)
        {
            return new ValidationResponse { Errors = new[] { new ValidationError(field, invalidMessage) } };
        }

        public static IResponse<T> Invalid<T>(string invalidMessage)
        {
            return new ValidationResponse<T> { Errors = new[] { new ValidationError(null, invalidMessage) } };
        }

        public static IResponse<T> Invalid<T>(string field, string invalidMessage)
        {
            return new ValidationResponse<T> { Errors = new[] { new ValidationError(field, invalidMessage) } };
        }

        public static IResponse Error(string error = null)
        {
            return new ErrorResponse { Message = error };
        }

        public static IResponse<T> Error<T>(string error = null)
        {
            return new ErrorResponse<T> { Message = error };
        }

        public static IResponse Unauthorised(string message = null)
        {
            return new UnauthorisedResponse { Message = message };
        }

        public static IResponse<T> Unauthorised<T>(string message = null)
        {
            return new UnauthorisedResponse<T> { Message = message };
        }
    }
}