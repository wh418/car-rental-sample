using System;
using System.Threading.Tasks;
using CarRental.Data;
using CarRental.Data.Context;
using CarRental.Data.Repositories;
using CarRental.Data.Vehicles;
using FluentAssertions;
using Xunit;

namespace CarRental.UnitTests.Data
{
    public class RepositoryTests
    {
        private readonly EntityContext _context;

        public RepositoryTests()
        {
            _context = TestEntityFactory.SetupContext();
        }

        [Fact]
        public async Task Should_CreateUnitOfWork_When_ContextIsPassed()
        {
            // Arrange
            var unit = new UnitOfWork(_context);

            // Act
            // Assert
            unit.Should().NotBeNull();
        }

        [Fact]
        public async Task Should_ReturnVehicle_When_VehicleIsAdded()
        {
            // Arrange
            var unit = new UnitOfWork(_context);
            var vehiclesRepository = new Repository<Vehicle>(_context);
            var newVehicleId = Guid.NewGuid();

            // Act
            vehiclesRepository.Add(new Vehicle { Id = newVehicleId });
            await unit.CommitAsync();

            // Assert
            vehiclesRepository.GetAll().Should().HaveCountGreaterThan(0);
            vehiclesRepository.Get(newVehicleId).Id.Should().Be(newVehicleId);
        }
    }
}