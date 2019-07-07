using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using CarRental.Common.Extensions;
using CarRental.Common.Foundation.Responses;
using CarRental.Common.Foundation.Responses.Types;

namespace CarRental.Common.Validation.Providers
{
    public class ValidationProvider : IValidationProvider
    {
	    private readonly IServiceProvider _serviceProvider;

        public ValidationProvider(IServiceProvider serviceProvider)
        {
	        _serviceProvider = serviceProvider;
        }

        public async Task<IValidationResponse> Validate<T>(T t)
        {
            var validators = _serviceProvider.GetServices<IValidator<T>>();

            var results = await validators.Select(x => x.Validate(t)).WhenAll().ConfigureAwait(false);

            return new ValidationResponse { Errors = results.SelectMany(x => x).ToList() };
        }
    }
}
