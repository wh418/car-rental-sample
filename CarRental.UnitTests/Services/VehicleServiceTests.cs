using System.Linq;
using System.Threading.Tasks;
using CarRental.Core.Vehicles;
using CarRental.Core.Vehicles.Models;
using CarRental.Data;
using CarRental.Data.Repositories;
using FluentAssertions;
using Xunit;

namespace CarRental.UnitTests.Services
{
    public class VehicleServiceTests
    {
        private readonly VehicleService _vehicleService;

        public VehicleServiceTests()
        {
            var context = TestEntityFactory.SetupContext();
            _vehicleService = new VehicleService(new VehicleRepository(context), new UnitOfWork(context));
        }

        [Fact]
        public async Task GivenGetAvailableVehicles_WhenGetAll_ThenAllAvailableVehiclesReturned()
        {
            // Arrange
            var expectedVehicleCount = SampleData.GetVehicles().Count(x => x.IsDeleted == false);
            var vehiclesAvailable = await _vehicleService.GetAvailableVehicles(new VehicleFilter {Skip = 0, Take = expectedVehicleCount });

            // Act

            // Assert
            vehiclesAvailable.Results.Should().NotBeNull();
            vehiclesAvailable.Results.Should().HaveCount(expectedVehicleCount);
        }

        [Fact]
        public async Task GivenGetAvailableVehicles_WhenReservingVehicle_ThenAllAvailableVehiclesReturnedExcludingReservedVehicle()
        {
            // Arrange
            var expectedVehicleCount = SampleData.GetVehicles().Count(x => x.IsDeleted == false);
            var vehiclesAvailable = await _vehicleService.GetAvailableVehicles(new VehicleFilter { Skip = 0, Take = expectedVehicleCount });

            // Act
            var vehicleIdToReserve = vehiclesAvailable.Results.First().Id;
            await _vehicleService.NewVehicleReservation(new NewVehicleReservation {BookingName = "John Doe", VehicleId = vehicleIdToReserve });
            vehiclesAvailable = await _vehicleService.GetAvailableVehicles(new VehicleFilter { Skip = 0, Take = expectedVehicleCount });

            // Assert
            vehiclesAvailable.Results.Should().NotBeNull();
            vehiclesAvailable.Results.Should().HaveCount(expectedVehicleCount - 1);
            vehiclesAvailable.Results.Select(x => x.Id).Should().NotContain(vehicleIdToReserve);
        }
    }
}

