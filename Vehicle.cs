using System;
using System.Collections.Generic;

namespace CarParts;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public int? StartMiles { get; set; }

    public int? EndMiles { get; set; }

    public int? StartFuel { get; set; }

    public int? EndFuel { get; set; }

    public string? StartCondition { get; set; }

    public string? EndCondition { get; set; }

    public string? Issues { get; set; }

    public string? ReasonForTrip { get; set; }

    public bool? OilChangeNeeded { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
