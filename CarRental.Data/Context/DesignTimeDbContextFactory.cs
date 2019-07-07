using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CarRental.Data.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EntityContext>
    {
        public EntityContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<EntityContext>();
            builder.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString());
            return new EntityContext(builder.Options);
        }
    }
}
