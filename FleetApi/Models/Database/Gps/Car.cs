using System;
using System.Collections.Generic;

namespace FleetApi.Models.Database.Gps;

public partial class Car
{
    public int Id { get; set; }

    public string Vin { get; set; } = null!;

    public int BrandModelId { get; set; }

    public string LicensePlate { get; set; } = null!;

    public string? Color { get; set; }

    public DateOnly? PurchaseDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual BrandsModel BrandModel { get; set; } = null!;

    public virtual ICollection<GeoDatum> GeoData { get; set; } = new List<GeoDatum>();
}
