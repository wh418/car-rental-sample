using System.Collections.Generic;
using System.Linq;
using CarRental.Common.Validation.Responses;

namespace CarRental.Common.Foundation.Responses.Types
{
    public class ValidationResponse : IValidationResponse
    {
        public bool IsSuccessful => Status == ResponseStatus.Success || Status == ResponseStatus.SuccessButWarnings;

        public ResponseStatus Status => Type?.ToResponseStatus() ?? ResponseStatus.Success;

        public ValidationType? Type => Errors?.Any() == true ? Errors.Min(x => x.Type) : (ValidationType?)null;

        public IList<ValidationError> Errors { get; set; }
    }

    public class ValidationResponse<T> : ValidationResponse, IValidationResponse<T>
    {
        public T Result { get; set; }
    }
}