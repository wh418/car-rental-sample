using System;
using System.Threading.Tasks;
using CarRental.Data.Context;
using CarRental.Data.Repositories;
using CarRental.Data.Repositories.Interfaces;
using CarRental.Data.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Data.Config
{
    public static class EntityBindings
    {
        public static IServiceCollection ConfigureEntityBindings(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddSingleton<IUnitOfWork, UnitOfWork>()
                .AddSingleton<IRepository<Vehicle>, Repository<Vehicle>>()
                .AddSingleton<IVehicleRepository, VehicleRepository>()
                .AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<EntityContext>(options => ConfigureDbContext(configuration, options), ServiceLifetime.Transient, ServiceLifetime.Singleton);
        }

        private static void ConfigureDbContext(IConfiguration configuration, DbContextOptionsBuilder options)
        {
            options
                .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning))
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
        }

        public static async Task SetupEntity(this IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<EntityContext>();
                await SeedContext(context);
                //  await context.Database.MigrateAsync();
            }
        }

        public static async Task SeedContext(EntityContext dbContext)
        {
            dbContext.Vehicles.AddRange(SampleData.GetVehicles());
            await dbContext.SaveChangesAsync();
        }
    }
}
