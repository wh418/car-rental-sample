using System.Threading.Tasks;
using CarRental.Common.Foundation.Responses;

namespace CarRental.Common.Validation.Providers
{
    public interface IValidationProvider
    {
        Task<IValidationResponse> Validate<T>(T t);
    }
}