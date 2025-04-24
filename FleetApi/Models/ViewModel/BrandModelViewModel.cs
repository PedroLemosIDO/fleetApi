namespace FleetApi.Models.ViewModel
{
    public class BrandModelViewModel
    {
        public int Id { get; set; }

        public string BrandName { get; set; } = null!;

        public string ModelName { get; set; } = null!;

        public int? Year { get; set; }
    }
}
