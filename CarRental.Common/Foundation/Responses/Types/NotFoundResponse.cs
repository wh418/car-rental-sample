using System.Collections.Generic;
using CarRental.Common.Validation;
using CarRental.Common.Validation.Responses;

namespace CarRental.Common.Foundation.Responses.Types
{
    public class NotFoundResponse : IResponse, IHasMessageResponse
    {
        public bool IsSuccessful => false;
        public ResponseStatus Status => ResponseStatus.NotFound;
        public string Message { get; set; }
    }

    public class NotFoundResponse<T> : NotFoundResponse, IResponse<T>
    {
        public T Result => default(T);
    }

    public class NotFoundValidationResponse<T> : NotFoundResponse<T>, IValidationResponse<T>
    {
        public bool HasWarnings => false;
        public IList<ValidationError> All => null;
        public IList<ValidationError> Warnings => null;
        public IList<ValidationError> Errors => null;
        public ValidationType? Type => ValidationType.NotFound;
    }
}