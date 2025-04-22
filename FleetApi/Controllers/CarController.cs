using Microsoft.AspNetCore.Mvc;

namespace FleetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
         

        private readonly ILogger<CarController> _logger;

        public CarController(ILogger<CarController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCars")]
        public IEnumerable<Data> Get()
        {
            return new List<Data>
            {
                new Data
                {
                    Date = DateOnly.FromDateTime(DateTime.Now),
                    TemperatureC = 20,
                    Summary = "Sunny"
                },
                new Data
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                    TemperatureC = 25,
                    Summary = "Cloudy"
                },
                new Data
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                    TemperatureC = 30,
                    Summary = "Rainy"
                }
            };
            //return Enumerable.Range(1, 5).Select(index => new Data
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
