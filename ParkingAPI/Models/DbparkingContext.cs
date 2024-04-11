using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ParkingAPI.Models;

public partial class DbparkingContext : DbContext
{
    public DbparkingContext()
    {
    }

    public DbparkingContext(DbContextOptions<DbparkingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<VehicleEntryExit> VehicleEntryExits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.IdCompany).HasName("PK__Company__3AF752DF5565874E");

            entity.ToTable("Company");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telephone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.IdVehicle).HasName("PK__Vehicle__64D74CC842019A6A");

            entity.ToTable("Vehicle");

            entity.Property(e => e.Brand)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Model)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Plate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VehicleEntryExit>(entity =>
        {
            entity.HasKey(e => e.EntryExitId).HasName("PK__VehicleE__9F92DC2B15F8DAB2");

            entity.ToTable("VehicleEntryExit");

            entity.Property(e => e.EntryExitId).HasColumnName("EntryExitID");
            entity.Property(e => e.CompanyId).HasColumnName("CompanyID");
            entity.Property(e => e.EntryTime).HasColumnType("datetime");
            entity.Property(e => e.ExitTime).HasColumnType("datetime");
            entity.Property(e => e.VehicleId).HasColumnName("VehicleID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
