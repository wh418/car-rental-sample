using System;
using CarRental.Data;
using CarRental.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CarRental.UnitTests
{
    public static class TestEntityFactory
    {
        public static EntityContext SetupContext(bool seedContext = true)
        {
            var options = new DbContextOptionsBuilder<EntityContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var dbContext = new EntityContext(options);

            if (seedContext)
                SeedContext(dbContext);

            return dbContext;
        }

        public static void SeedContext(EntityContext dbContext)
        {
            dbContext.Vehicles.AddRange(SampleData.GetVehicles());
            dbContext.SaveChanges();
        }
    }
}