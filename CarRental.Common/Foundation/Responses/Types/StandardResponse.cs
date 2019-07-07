using System;
using System.Collections.Generic;
using System.Linq;
using CarRental.Common.Extensions;
using CarRental.Common.Validation;
using CarRental.Common.Validation.Responses;

namespace CarRental.Common.Foundation.Responses.Types
{
    internal class StandardResponse : IResponse, IHasMessageResponse, IHasErrorsResponse
    {
        public bool IsSuccessful => Status == ResponseStatus.Success || Status == ResponseStatus.SuccessButWarnings;
        public ResponseStatus Status { get; }
        public string Message { get; }
        public IList<ValidationError> Errors { get; }

        internal StandardResponse(IResponse response)
        {
            var hasErrors = response as IHasErrorsResponse;
            var message = (response as IHasMessageResponse)?.Message
                ?? hasErrors?.Errors.Select(x => x.Message).Distinct().JoinString(Environment.NewLine)
                ?? response.Status.GetDefaultMessage();

            Status = response.Status;
            Errors = hasErrors?.Errors ?? new[] {new ValidationError { Message = message}};
            Message = message;
        }

        internal StandardResponse(ResponseStatus status, string message, IList<ValidationError> errors)
        {
            Status = status;
            Message = message;
            Errors = errors;
        }
    }

    internal class StandardResponse<T> : StandardResponse, IResponse<T>
    {
        public T Result { get; }

        internal StandardResponse(IResponse response, T result = default(T)) : base(response)
        {
            Result = result;
        }

        internal StandardResponse(ResponseStatus status, string message, IList<ValidationError> errors, T model) : base(status, message, errors)
        {
            Result = model;
        }
    }
}
