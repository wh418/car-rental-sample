using System.Net;
using CarRental.Common.Foundation.Responses;

namespace CarRental.Common.Validation.Responses
{
    public enum ValidationType
    {
        Unauthorized = 1,
        NotFound = 2,
        Invalid = 3
    }

    public static class ValidationTypeExtensions
    {
        public static ResponseStatus ToResponseStatus(this ValidationType type)
        {
            switch (type)
            {
                case ValidationType.Unauthorized:
                    return ResponseStatus.Unauthorised;
                case ValidationType.NotFound:
                    return ResponseStatus.NotFound;
                case ValidationType.Invalid:
                default:
                    return ResponseStatus.Invalid;
            }
        }
    }
}