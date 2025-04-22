using System;
using System.Collections.Generic;

namespace FleetApi.Models.Database.Gps;

public partial class BrandsModel
{
    public int Id { get; set; }

    public string BrandName { get; set; } = null!;

    public string ModelName { get; set; } = null!;

    public int? Year { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
