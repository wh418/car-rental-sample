using System.Threading.Tasks;
using CarRental.Data.Context;
using FluentAssertions;
using Xunit;

namespace CarRental.UnitTests.Data
{
    public class ContextTests
    {
        private readonly EntityContext _context;

        public ContextTests()
        {
            _context = TestEntityFactory.SetupContext();
        }

        [Fact]
        public async Task Should_CreateContext_When_Initialised()
        {
            // Arrange
            // Act
            // Assert
            _context.Vehicles.Should().NotBeNull();
            _context.Vehicles.Should().HaveCountGreaterThan(0);
        }
    }
}
