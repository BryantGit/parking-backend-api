using System;
using System.Collections.Generic;

namespace ParkingAPI.Models;

public partial class Vehicle
{
    public int IdVehicle { get; set; }

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string Plate { get; set; } = null!;

    public string Type { get; set; } = null!;
}
