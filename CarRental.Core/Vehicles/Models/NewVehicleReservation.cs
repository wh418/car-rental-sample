using System;

namespace CarRental.Core.Vehicles.Models
{
    public class NewVehicleReservation
    {
        public Guid VehicleId { get; set; }
        public string BookingName { get; set; }
    }
}
