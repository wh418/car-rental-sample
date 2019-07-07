using System;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Common.Foundation.Paging;
using CarRental.Data.Context;
using CarRental.Data.Repositories.Interfaces;
using CarRental.Data.Vehicles;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Data.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        private readonly EntityContext _context;
        public VehicleRepository(EntityContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IPagedList<Vehicle>> GetAvailableVehicles(PagedFilter filter)
        {
            var vehicleListAsync = await _context.Vehicles.Where(x => x.IsDeleted == false && x.BookingDate.AddHours(24) < DateTime.UtcNow).OrderBy(x => x.Make).ThenBy(x => x.Model).Skip(filter.Skip)
                .Take(filter.Take).ToListAsync();
            return new PagedList<Vehicle>
            {
                Take = filter.Take,
                Skip = filter.Skip,
                Total = vehicleListAsync.Count,
                Results = vehicleListAsync
            };
        }
    }
}