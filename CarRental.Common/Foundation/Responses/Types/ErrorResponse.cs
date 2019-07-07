using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using CarRental.Common.Validation;
using CarRental.Common.Validation.Responses;

namespace CarRental.Common.Foundation.Responses.Types
{
    public class ErrorResponse : IResponse, IHasErrorsResponse, IHasMessageResponse
    {
        public bool IsSuccessful => false;
        public ResponseStatus Status => ResponseStatus.Error;
        public string Message { get; set; }
        public IList<ValidationError> Errors => new[] { new ValidationError { Message = Message }, };
    }

    public class ErrorResponse<T> : ErrorResponse, IResponse<T>
    {
        public T Result => default(T);
    }

    public class ExceptionResponse : IResponse
    {
        public bool IsSuccessful => false;
        public ResponseStatus Status => ResponseStatus.Error;

        [JsonIgnore]
        public Exception Exception { get; set; }
    }

    public class ExceptionResponse<T> : ExceptionResponse, IResponse<T>
    {
        public T Result => default(T);
    }
}