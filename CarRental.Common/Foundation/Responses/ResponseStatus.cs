using System.Net;

namespace CarRental.Common.Foundation.Responses
{
    public enum ResponseStatus
    {
        Success,
        SuccessButWarnings,
        Error,
        Unauthorised,
        Invalid,
        NotFound
    }

    public static class ResponseStatusExtensions
    {
        public static string GetDefaultMessage(this ResponseStatus status)
        {
            switch (status)
            {
                case ResponseStatus.Success:
                    return "Request was successful.";
                case ResponseStatus.SuccessButWarnings:
                    return "Request was successful but has warnings.";
                case ResponseStatus.Unauthorised:
                    return "You do not have access to do this.";
                case ResponseStatus.Invalid:
                    return "There was a problem with the request.";
                case ResponseStatus.NotFound:
                    return "We couldn't find what you were looking for.";
                case ResponseStatus.Error:
                default:
                    return "An error has occurred.";
            }
        }

        public static HttpStatusCode GetHttpStatusCode(this ResponseStatus status)
        {
            switch (status)
            {
                case ResponseStatus.Unauthorised:
                    return HttpStatusCode.Forbidden;
                case ResponseStatus.Invalid:
                    return HttpStatusCode.BadRequest;
                case ResponseStatus.NotFound:
                    return HttpStatusCode.NotFound;
                case ResponseStatus.Success:
                case ResponseStatus.SuccessButWarnings:
                    return HttpStatusCode.OK;
                case ResponseStatus.Error:
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }

        public static ResponseStatus ToResponseStatus(this HttpStatusCode status)
        {
            switch (status)
            {
                case HttpStatusCode.Forbidden:
                    return ResponseStatus.Unauthorised;
                case HttpStatusCode.BadRequest:
                    return ResponseStatus.Invalid;
                case HttpStatusCode.NotFound:
                    return ResponseStatus.NotFound;
                case HttpStatusCode.OK:
                case HttpStatusCode.Accepted:
                case HttpStatusCode.PartialContent:
                case HttpStatusCode.Created:
                case HttpStatusCode.NoContent:
                    return ResponseStatus.Success;
                default:
                    return ResponseStatus.Error;
            }
        }
    }
}