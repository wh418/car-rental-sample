using System.Collections.Generic;
using CarRental.Common.Validation;
using CarRental.Common.Validation.Responses;

namespace CarRental.Common.Foundation.Responses
{
    public interface IHasErrorsResponse
    {
        IList<ValidationError> Errors { get; }
    }
}