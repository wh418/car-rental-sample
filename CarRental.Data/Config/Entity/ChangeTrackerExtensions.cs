using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CarRental.Common.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CarRental.Data.Config.Entity
{
    public static class ChangeTrackerExtensions
    {
        public static void TrackUpdates(this ChangeTracker changeTracker)
        {
            changeTracker.Entries()
                .Where(x => x.State == EntityState.Modified)
                .Where(x => x.Entity is ITrackChanges)
                .Select(x => x.Entity as ITrackChanges)
                .ForEach(x => x.UpdatedOn = DateTime.UtcNow);
        }

        public static void SetupInMemoryTrackingFields<T>(this ModelBuilder modelBuilder) where T : DbContext
        {
            var entities = typeof(T).Assembly.DefinedTypes.Where(x => x.ImplementedInterfaces.Contains(typeof(ITrackChanges)));

            entities.ForEach(x =>
            {
                modelBuilder.Entity(x.AsType())
                    .Property("CreatedOn")
                    .HasColumnType("datetime")
                    .HasDefaultValue()
                    .ValueGeneratedOnAddOrUpdate();

                modelBuilder.Entity(x.AsType())
                    .Property("UpdatedOn")
                    .HasColumnType("datetime")
                    .HasDefaultValue()
                    .ValueGeneratedOnAddOrUpdate();
            });
        }
    }
}
