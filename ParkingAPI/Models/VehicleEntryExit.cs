using System;
using System.Collections.Generic;

namespace ParkingAPI.Models;

public partial class VehicleEntryExit
{
    public int EntryExitId { get; set; }

    public int? CompanyId { get; set; }

    public int? VehicleId { get; set; }

    public DateTime? EntryTime { get; set; }

    public DateTime? ExitTime { get; set; }
}
