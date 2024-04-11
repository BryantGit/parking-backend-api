using System;
using System.Collections.Generic;

namespace ParkingAPI.Models;

public partial class Company
{
    public int IdCompany { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public int NumMotorcycleSpaces { get; set; }

    public int NumCarSpaces { get; set; }
}
