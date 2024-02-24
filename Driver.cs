using System;
using System.Collections.Generic;

namespace CarParts;

public partial class Driver
{
    public int DriverId { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? Dob { get; set; }

    public string? AddressStreet { get; set; }

    public string? AddressZip { get; set; }

    public string? LicenseNumber { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
