using System.Collections.Generic;
using System.Threading.Tasks;
using CarRental.Common.Foundation.Paging;
using CarRental.Common.Foundation.Responses;
using CarRental.Core.Vehicles.Models;

namespace CarRental.Core.Vehicles.Interfaces
{
    public interface IVehicleService
    {
        Task<IResponse> NewVehicleReservation(NewVehicleReservation newVehicleReservation);
        Task<IPagedList<VehicleListingVm>> GetAvailableVehicles(PagedFilter filter);
    }
}