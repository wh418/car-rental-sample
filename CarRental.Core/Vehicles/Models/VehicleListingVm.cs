using System;

namespace CarRental.Core.Vehicles.Models
{
    public class VehicleListingVm
    {
        public Guid Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
