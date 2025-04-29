using FleetApi.Models.Database.Gps;
using FleetApi.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [Route("GetCarByPlate", Name = "GetCarByPlate")]
        [HttpGet]
        public IActionResult GetByPlate(string plate)
        {
            var car = _internsqlContext.Cars.Where(carTmp => carTmp.LicensePlate.Equals(plate)).FirstOrDefault();

            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [Route("GetCars", Name = "GetCars")]
        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = _internsqlContext
                .Cars
                .Include(x => x.BrandModel)
                .Include(x => x.GeoData)
                .Select(car => new
                {
                    Id = car.Id,
                    Vin = car.Vin,
                    BrandModelId = car.BrandModelId,
                    LicensePlate = car.LicensePlate,
                    Color = car.Color,
                    PurchaseDate = car.PurchaseDate,
                    IsActive = car.IsActive,
                    BrandModel = new BrandModelViewModel()
                    {
                        Id = car.BrandModel.Id,
                        BrandName = car.BrandModel.BrandName,
                        ModelName = car.BrandModel.ModelName,
                        Year = car.BrandModel.Year
                    },
                    GeoDataPoints = car.GeoData.Select(g => new GeoDataViewModel()
                    {
                        Id = g.Id,
                        Latitude = g.Latitude,
                        Longitude = g.Longitude,
                        HeadingDeg = g.HeadingDeg,
                        SpeedKph = g.SpeedKph,
                        RecordedAt = g.RecordedAt,
                        Ignition = g.Ignition
                    }).AsQueryable().OrderByDescending(x => x.RecordedAt).Take(1).ToList(),
                }).ToList();

            if (cars == null)
            {
                return NotFound();
            }
            return Ok(cars);
        }
    }
}
