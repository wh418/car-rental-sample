using System.Threading;
using System.Threading.Tasks;
using CarRental.Data.Config.Entity;
using CarRental.Data.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data.Context
{
    public class EntityContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            ChangeTracker.TrackUpdates();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ChangeTracker.TrackUpdates();
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.SetupInMemoryTrackingFields<EntityContext>();
        }
    }
}
