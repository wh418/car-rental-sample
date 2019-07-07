using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarRental.Common.Foundation.Paging;
using CarRental.Common.Foundation.Responses;
using CarRental.Core.Vehicles.Interfaces;
using CarRental.Core.Vehicles.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet("")]
        public async Task<IPagedList<VehicleListingVm>> GetAvailableVehicles(int skip, int take)
        {
            return await _vehicleService.GetAvailableVehicles(new VehicleFilter {Skip = skip, Take = take});
        }

        [HttpPost("reservations")]
        public async Task<IResponse> NewVehicleReservation([FromBody]NewVehicleReservation newVehicleReservation)
        {
            return await _vehicleService.NewVehicleReservation(newVehicleReservation);
        }
    }
}
