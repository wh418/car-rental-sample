using System;
using System.Threading.Tasks;
using CarRental.Common.Foundation.Paging;
using CarRental.Data.Vehicles;

namespace CarRental.Data.Repositories.Interfaces
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Task<IPagedList<Vehicle>> GetAvailableVehicles(PagedFilter filter);
    }
}