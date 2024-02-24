using System;
using System.Collections.Generic;

namespace CarParts;

public partial class Trip
{
    public int TripId { get; set; }

    public string? DestinationAddress { get; set; }

    public string? DestinationZip { get; set; }

    public string? ToDate { get; set; }

    public string? ToStartTime { get; set; }

    public string? ToArrivalTime { get; set; }

    public string? BackDate { get; set; }

    public string? BackStartTime { get; set; }

    public string? BackArrivalTime { get; set; }

    public int? VehicleId { get; set; }

    public int? DriverId { get; set; }

    public int? PassengerId { get; set; }

    public virtual Driver? Driver { get; set; }

    public virtual Passenger? Passenger { get; set; }

    public virtual Vehicle? Vehicle { get; set; }
}
