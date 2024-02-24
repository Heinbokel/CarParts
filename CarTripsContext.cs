using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarParts;

public partial class CarTripsContext : DbContext
{
    public CarTripsContext()
    {
    }

    public CarTripsContext(DbContextOptions<CarTripsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Passenger> Passengers { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=CarTrips.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Driver>(entity =>
        {
            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.AddressStreet)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("address_street");
            entity.Property(e => e.AddressZip)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("address_zip");
            entity.Property(e => e.Dob)
                .HasColumnType("DATE")
                .HasColumnName("dob");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.LicenseNumber).HasColumnName("license_number");
            entity.Property(e => e.MiddleName).HasColumnName("middle_name");
        });

        modelBuilder.Entity<Passenger>(entity =>
        {
            entity.Property(e => e.PassengerId).HasColumnName("passenger_id");
            entity.Property(e => e.AddressStreet)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("address_street");
            entity.Property(e => e.AddressZip)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("address_zip");
            entity.Property(e => e.Dob)
                .HasColumnType("DATE")
                .HasColumnName("dob");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.MiddleName).HasColumnName("middle_name");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.Property(e => e.TripId).HasColumnName("trip_id");
            entity.Property(e => e.BackArrivalTime)
                .HasColumnType("TIME")
                .HasColumnName("back_arrival_time");
            entity.Property(e => e.BackDate)
                .HasColumnType("DATE")
                .HasColumnName("back_date");
            entity.Property(e => e.BackStartTime)
                .HasColumnType("TIME")
                .HasColumnName("back_start_time");
            entity.Property(e => e.DestinationAddress)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("destination_address");
            entity.Property(e => e.DestinationZip)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("destination_zip");
            entity.Property(e => e.DriverId).HasColumnName("driver_id");
            entity.Property(e => e.PassengerId).HasColumnName("passenger_id");
            entity.Property(e => e.ToArrivalTime)
                .HasColumnType("TIME")
                .HasColumnName("to_arrival_time");
            entity.Property(e => e.ToDate)
                .HasColumnType("DATE")
                .HasColumnName("to_date");
            entity.Property(e => e.ToStartTime)
                .HasColumnType("TIME")
                .HasColumnName("to_start_time");
            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

            entity.HasOne(d => d.Driver).WithMany(p => p.Trips).HasForeignKey(d => d.DriverId);

            entity.HasOne(d => d.Passenger).WithMany(p => p.Trips).HasForeignKey(d => d.PassengerId);

            entity.HasOne(d => d.Vehicle).WithMany(p => p.Trips).HasForeignKey(d => d.VehicleId);
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
            entity.Property(e => e.EndCondition).HasColumnName("end_condition");
            entity.Property(e => e.EndFuel).HasColumnName("end_fuel");
            entity.Property(e => e.EndMiles).HasColumnName("end_miles");
            entity.Property(e => e.Issues).HasColumnName("issues");
            entity.Property(e => e.OilChangeNeeded)
                .HasColumnType("BOOLEAN")
                .HasColumnName("oil_change_needed");
            entity.Property(e => e.ReasonForTrip).HasColumnName("reason_for_trip");
            entity.Property(e => e.StartCondition).HasColumnName("start_condition");
            entity.Property(e => e.StartFuel).HasColumnName("start_fuel");
            entity.Property(e => e.StartMiles).HasColumnName("start_miles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
