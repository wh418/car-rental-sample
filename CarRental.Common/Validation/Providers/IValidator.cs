using System.Collections.Generic;
using System.Threading.Tasks;
using CarRental.Common.Validation.Responses;

namespace CarRental.Common.Validation.Providers
{
    public interface IValidator<in T>
    {
        Task<IEnumerable<ValidationError>> Validate(T t);
    }
}