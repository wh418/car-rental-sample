using System;

namespace CarRental.Data.Config.Entity
{
    public interface ITrackChanges
    {
        DateTime CreatedOn { get; set; }
        DateTime UpdatedOn { get; set; }
    }
}
