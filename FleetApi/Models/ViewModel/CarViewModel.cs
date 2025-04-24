using FleetApi.Models.Database.Gps;

namespace FleetApi.Models.ViewModel
{
    public class CarViewModel
    {
        public int Id { get; set; }

        public string Vin { get; set; } = null!;

        public int BrandModelId { get; set; }

        public string LicensePlate { get; set; } = null!;

        public string? Color { get; set; }

        public DateOnly? PurchaseDate { get; set; }

        public bool? IsActive { get; set; }
         
    }
}

