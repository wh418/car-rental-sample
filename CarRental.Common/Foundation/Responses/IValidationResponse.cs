using CarRental.Common.Validation.Responses;

namespace CarRental.Common.Foundation.Responses
{
    public interface IValidationResponse : IResponse, IHasErrorsResponse
    {
        ValidationType? Type { get; }
    }

    public interface IValidationResponse<out T> : IValidationResponse, IResponse<T>
    {
    }
}