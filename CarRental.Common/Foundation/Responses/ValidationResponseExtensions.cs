using System.Collections.Generic;
using CarRental.Common.Foundation.Responses.Types;
using CarRental.Common.Validation;
using CarRental.Common.Validation.Responses;

namespace CarRental.Common.Foundation.Responses
{
    public static class ValidationResponseExtensions
    {
        public static IValidationResponse<T> ToValidationResponse<T>(this T t)
        {
            if (t == null)
                return new NotFoundValidationResponse<T>();

            return new ValidationResponse<T>
            {
                Result = t
            };
        }
        
        public static IValidationResponse<T> ToValidationResponse<T>(this IList<ValidationError> errors)
        {
            return new ValidationResponse<T> { Errors = errors };
        }
    }
}