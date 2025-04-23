using FleetApi.Models.Database.Gps;
using Microsoft.AspNetCore.Mvc;

namespace FleetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly InternsqlContext _internsqlContext;

        private readonly ILogger<CarsController> _logger;

        public CarsController(ILogger<CarsController> logger, InternsqlContext context)
        {
            _logger = logger;
            _internsqlContext = context;
        }

        [HttpGet(Name = "GetCar")]
        public IActionResult Get(int id)
        {
            var car = _internsqlContext.Cars.Find(id);

            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [Route("GetCar2", Name = "GetCar2")]
        [HttpGet]
        public IActionResult Get2(int id)
        {
            var car = _internsqlContext.Cars.Find(id);

            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [Route("GetCarByPlate", Name = "GetCarByPlate")]
        [HttpGet]
        public IActionResult GetByPlate(string plate)
        {
            var car = _internsqlContext.Cars.Where(carTmp=>carTmp.LicensePlate.Equals(plate)).FirstOrDefault();

            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [Route("GetCars2",Name = "GetCars")]
        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = _internsqlContext.Cars.ToList();

            if (cars == null)
            {
                return NotFound();
            }
            return Ok(cars);
        }
    }
}
