using System;
using CarRental.Common.Foundation.Responses;
using CarRental.Common.Validation.Responses;

namespace CarRental.Common.Exceptions
{
    public static class ExceptionExtensions
    {
        public static Exception ToException(this IValidationResponse validationResponse)
        {
            if (validationResponse.Type == null)
                throw new ArgumentOutOfRangeException(nameof(validationResponse), "No validation errors");

            if (validationResponse.Type == ValidationType.Unauthorized)
                return new UnauthorizedException();

            if (validationResponse.Type == ValidationType.NotFound)
                return new NotFoundException();

            return new ValidationException(validationResponse.Errors);
        }

    }
}
