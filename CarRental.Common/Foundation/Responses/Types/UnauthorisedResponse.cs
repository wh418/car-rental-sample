using System.Collections.Generic;
using CarRental.Common.Validation;
using CarRental.Common.Validation.Responses;

namespace CarRental.Common.Foundation.Responses.Types
{
    public class UnauthorisedResponse : IResponse, IHasErrorsResponse, IHasMessageResponse
    {
        public bool IsSuccessful => false;
        public ResponseStatus Status => ResponseStatus.Unauthorised;
        public string Message { get; set; }
        public IList<ValidationError> Errors => new[] { new ValidationError { Message = Message } };
    }

    public class UnauthorisedResponse<T> : UnauthorisedResponse, IResponse<T>
    {
        public T Result => default(T);
    }
}