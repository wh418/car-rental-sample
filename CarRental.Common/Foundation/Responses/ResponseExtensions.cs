using System;
using System.Collections.Generic;
using System.Linq;
using CarRental.Common.Extensions;
using CarRental.Common.Foundation.Responses.Types;
using CarRental.Common.Validation;
using CarRental.Common.Validation.Responses;

namespace CarRental.Common.Foundation.Responses
{
    public static class ResponseExtensions
    {
        public static IResponse<T> ToResponse<T>(this T t)
        {
            if (t == null)
                return new NotFoundResponse<T>();

            return new Response<T>
            {
                Status = ResponseStatus.Success,
                Result = t
            };
        }


        public static IResponse ToResponse(this IList<ValidationError> errors)
        {
            return new ValidationResponse { Errors = errors };
        }
        public static IResponse<T> ToResponse<T>(this IList<ValidationError> errors)
        {
            return new ValidationResponse<T> { Errors = errors };
        }

        public static IResponse AsValidationResponse(this IList<ValidationError> errors)
        {
            return new ValidationResponse { Errors = errors };
        }

        public static IResponse<T> AsValidationResponse<T>(this IList<ValidationError> errors)
        {
            return new ValidationResponse<T> { Errors = errors };
        }

        public static IResponse ToResponse(this Exception e)
        {
            return new ExceptionResponse {Exception = e};
        }

        public static IResponse<T> ToResponse<T>(this Exception e)
        {
            return new ExceptionResponse<T> { Exception = e };
        }

        /// <summary>
        /// Copies the response and converts it to an Response<T> with the provided result or its default.
        /// </summary>
        public static IResponse<TV> ToResponse<T, TV>(this IResponse<T> response, TV result = default(TV))
        {
            return new StandardResponse<TV>(response, result);
        }

        /// <summary>
        /// Copies the response and converts it to an Response<T> with the provided result or its default.
        /// </summary>
        public static IResponse<T> ToResponse<T>(this IResponse response, T result = default(T))
        {
            return new StandardResponse<T>(response, result);
        }

        public static string GetMessage(this IResponse response)
        {
            var hasErrors = response as IHasErrorsResponse;
            var message = (response as IHasMessageResponse)?.Message
                ?? hasErrors?.Errors.Select(x => x.Message).Distinct().JoinString(Environment.NewLine)
                ?? (response as ExceptionResponse)?.Exception.ToString()
                ?? response.Status.GetDefaultMessage();

            return message;
        }
    }
}