using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarRental.Core.Vehicles;
using CarRental.Core.Vehicles.Interfaces;
using CarRental.Data.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Core.Config
{
    public static class CoreBindings
    {
        public static IServiceCollection ConfigureCoreBindings(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .ConfigureEntityBindings(configuration)
                .AddSingleton<IVehicleService, VehicleService>();
        }

        public static async Task SetupCore(this IServiceProvider serviceProvider)
        {
            await serviceProvider.SetupEntity();
        }
    }
}
