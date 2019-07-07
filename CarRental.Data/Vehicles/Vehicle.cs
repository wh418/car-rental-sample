using System;
using System.ComponentModel.DataAnnotations;
using CarRental.Data.Config.Entity;

namespace CarRental.Data.Vehicles
{
    public class Vehicle : ITrackChanges
    {
        public Guid Id { get; set; }
        [MaxLength(50), Required]
        public string Make { get; set; }
        [MaxLength(50), Required]
        public string Model { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public DateTime BookingDate { get; set; }
        [MaxLength(200), Required]
        public string BookingName { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
