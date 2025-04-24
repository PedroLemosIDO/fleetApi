namespace FleetApi.Models.ViewModel
{
    public class GeoDataViewModel
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public DateTime? RecordedAt { get; set; }

        public decimal? SpeedKph { get; set; }

        public decimal? HeadingDeg { get; set; }
    }
}
