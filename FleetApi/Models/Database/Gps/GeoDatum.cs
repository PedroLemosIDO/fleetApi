using System;
using System.Collections.Generic;

namespace FleetApi.Models.Database.Gps;

public partial class GeoDatum
{
    public int Id { get; set; }

    public int CarId { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public DateTime? RecordedAt { get; set; }

    public decimal? SpeedKph { get; set; }

    public decimal? HeadingDeg { get; set; }

    public virtual Car Car { get; set; } = null!;
}
