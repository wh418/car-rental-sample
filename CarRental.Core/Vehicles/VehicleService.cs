using System;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Common.Foundation.Paging;
using CarRental.Common.Foundation.Responses;
using CarRental.Core.Vehicles.Interfaces;
using CarRental.Core.Vehicles.Models;
using CarRental.Data;
using CarRental.Data.Repositories.Interfaces;

namespace CarRental.Core.Vehicles
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public VehicleService(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
        {
            _vehicleRepository = vehicleRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResponse> NewVehicleReservation(NewVehicleReservation newVehicleReservation)
        {
            var vehicle = await _vehicleRepository.GetAsync(newVehicleReservation.VehicleId);
            if (vehicle == null)
                return ResponseType.NotFound();
            vehicle.BookingName = newVehicleReservation.BookingName;
            var vehicleBookingDate = DateTime.UtcNow;
            vehicle.BookingDate = vehicleBookingDate;
            vehicle.UpdatedOn = vehicleBookingDate;
            await _unitOfWork.CommitAsync();
            return ResponseType.Success;
        }

        public async Task<IPagedList<VehicleListingVm>> GetAvailableVehicles(PagedFilter filter)
        {
            var availableVehicles = await _vehicleRepository.GetAvailableVehicles(filter);
            return new PagedList<VehicleListingVm>
            {
                Take = availableVehicles.Take,
                Skip = availableVehicles.Skip,
                Total = availableVehicles.Total,
                Results = availableVehicles.Results.Select(x => new VehicleListingVm {Id = x.Id, Make = x.Make, Model = x.Model, IsDeleted = x.IsDeleted, CreatedOn = x.CreatedOn, UpdatedOn = x.UpdatedOn}).ToList()
            };
        }
    }
}