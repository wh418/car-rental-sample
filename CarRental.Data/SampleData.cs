using System;
using System.Collections.Generic;
using CarRental.Data.Vehicles;

namespace CarRental.Data
{
    public static class SampleData
    {
        public static IEnumerable<Vehicle> GetVehicles()
        {
            yield return new Vehicle
            {
                Id = Guid.NewGuid(),
                Make = "Hyundai",
                Model = "Tuscon",
                IsDeleted = false,
                CreatedOn = DateTime.UtcNow.AddDays(-2),
                UpdatedOn = DateTime.UtcNow.AddDays(-1)
            };
            yield return new Vehicle
            {
                Id = Guid.NewGuid(),
                Make = "Toyota",
                Model = "Camry",
                IsDeleted = false,
                CreatedOn = DateTime.UtcNow.AddDays(-2),
                UpdatedOn = DateTime.UtcNow.AddDays(-1)
            };
            yield return new Vehicle
            {
                Id = Guid.NewGuid(),
                Make = "Audi",
                Model = "A4",
                IsDeleted = false,
                CreatedOn = DateTime.UtcNow.AddDays(-2),
                UpdatedOn = DateTime.UtcNow.AddDays(-1)
            };
            yield return new Vehicle
            {
                Id = Guid.NewGuid(),
                Make = "Audi",
                Model = "A6",
                IsDeleted = true,
                CreatedOn = DateTime.UtcNow.AddDays(-2),
                UpdatedOn = DateTime.UtcNow.AddDays(-1)
            };
        }
    }
}