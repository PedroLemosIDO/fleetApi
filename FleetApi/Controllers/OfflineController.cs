using FleetApi.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FleetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OfflineController : ControllerBase
    {
        [Route("GetCarsOffline", Name = "GetCarsOffline")]
        [HttpGet]
        public IActionResult GetCarsOffline()
        {
            var cars = new[]
            {
                new
                {
                    Id = 1,
                    Vin = "1HGCM82633A123456",
                    BrandModelId = 101,
                    LicensePlate = "ABC1234",
                    Color = "Black",
                    PurchaseDate = new DateTime(2021, 5, 15),
                    IsActive = true,
                    BrandModel = new BrandModelViewModel
                    {
                        Id = 101,
                        BrandName = "Toyota",
                        ModelName = "Corolla",
                        Year = 2021
                    },
                    LastKnownLocation = new GeoDataViewModel
                    {
                        Id = 1,
                        Latitude = 52.2297m,
                        Longitude = 21.0122m,
                        HeadingDeg = 90,
                        SpeedKph = 50,
                        RecordedAt = DateTime.UtcNow.AddMinutes(-10),
                        Ignition = true
                    }
                },
                new
                {
                    Id = 2,
                    Vin = "WDBUF56X28B123457",
                    BrandModelId = 102,
                    LicensePlate = "XYZ5678",
                    Color = "White",
                    PurchaseDate = new DateTime(2020, 11, 3),
                    IsActive = false,
                    BrandModel = new BrandModelViewModel
                    {
                        Id = 102,
                        BrandName = "Mercedes",
                        ModelName = "E-Class",
                        Year = 2020
                    },
                    LastKnownLocation = new GeoDataViewModel
                    {
                        Id = 2,
                        Latitude = 40.7128m,
                        Longitude = -74.0060m,
                        HeadingDeg = 180,
                        SpeedKph = 0,
                        RecordedAt = DateTime.UtcNow.AddHours(-1),
                        Ignition = false
                    }
                },
                new
                {
                    Id = 3,
                    Vin = "3FAHP0HA1AR123458",
                    BrandModelId = 103,
                    LicensePlate = "JKL9012",
                    Color = "Red",
                    PurchaseDate = new DateTime(2022, 2, 20),
                    IsActive = true,
                    BrandModel = new BrandModelViewModel
                    {
                        Id = 103,
                        BrandName = "Ford",
                        ModelName = "Fusion",
                        Year = 2022
                    },
                    LastKnownLocation = new GeoDataViewModel
                    {
                        Id = 3,
                        Latitude = 34.0522m,
                        Longitude = -118.2437m,
                        HeadingDeg = 45,
                        SpeedKph = 65,
                        RecordedAt = DateTime.UtcNow.AddMinutes(-5),
                        Ignition = true
                    }
                },
                new
                {
                    Id = 4,
                    Vin = "2T1BURHE5JC123459",
                    BrandModelId = 104,
                    LicensePlate = "MNO3456",
                    Color = "Blue",
                    PurchaseDate = new DateTime(2023, 7, 1),
                    IsActive = true,
                    BrandModel = new BrandModelViewModel
                    {
                        Id = 104,
                        BrandName = "Honda",
                        ModelName = "Civic",
                        Year = 2023
                    },
                    LastKnownLocation = new GeoDataViewModel
                    {
                        Id = 4,
                        Latitude = 51.5074m,
                        Longitude = -0.1278m,
                        HeadingDeg = 270,
                        SpeedKph = 30,
                        RecordedAt = DateTime.UtcNow.AddMinutes(-20),
                        Ignition = true
                    }
                },
                new
                {
                    Id = 5,
                    Vin = "5YJSA1E26GF123460",
                    BrandModelId = 105,
                    LicensePlate = "PQR7890",
                    Color = "Silver",
                    PurchaseDate = new DateTime(2019, 9, 10),
                    IsActive = false,
                    BrandModel = new BrandModelViewModel
                    {
                        Id = 105,
                        BrandName = "Tesla",
                        ModelName = "Model S",
                        Year = 2019
                    },
                    LastKnownLocation = new GeoDataViewModel
                    {
                        Id = 5,
                        Latitude = 37.7749m,
                        Longitude = -122.4194m,
                        HeadingDeg = 135,
                        SpeedKph = 0,
                        RecordedAt = DateTime.UtcNow.AddDays(-1),
                        Ignition = false
                    }
                }
            };
            
            return Ok(cars);
        }

        [Route("GetGeoDataByCarIDAllOffline", Name = "GetGeoDataByCarIDAllOffline")]
        [HttpGet]
        public IActionResult GetGeoDataByCarIDAllOffline(int id)
        {
            var geoDataPoints = new List<GeoDataViewModel>
            {
                new GeoDataViewModel
                {
                    Id = 1,
                    CarId = 1,
                    Latitude = 52.2297m,
                    Longitude = 21.0122m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-50),
                    SpeedKph = 30m,
                    HeadingDeg = 90m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 2,
                    CarId = 1,
                    Latitude = 52.2300m,
                    Longitude = 21.0150m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-48),
                    SpeedKph = 40m,
                    HeadingDeg = 92m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 3,
                    CarId = 1,
                    Latitude = 52.2310m,
                    Longitude = 21.0180m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-46),
                    SpeedKph = 50m,
                    HeadingDeg = 95m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 4,
                    CarId = 1,
                    Latitude = 52.2312m,
                    Longitude = 21.0185m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-44),
                    SpeedKph = 0m,
                    HeadingDeg = 0m,
                    Ignition = false
                },
                new GeoDataViewModel
                {
                    Id = 5,
                    CarId = 1,
                    Latitude = 52.2312m,
                    Longitude = 21.0185m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-42),
                    SpeedKph = 0m,
                    HeadingDeg = 0m,
                    Ignition = false
                },
                new GeoDataViewModel
                {
                    Id = 6,
                    CarId = 1,
                    Latitude = 52.2320m,
                    Longitude = 21.0200m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-40),
                    SpeedKph = 35m,
                    HeadingDeg = 100m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 7,
                    CarId = 1,
                    Latitude = 52.2330m,
                    Longitude = 21.0220m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-38),
                    SpeedKph = 45m,
                    HeadingDeg = 105m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 8,
                    CarId = 1,
                    Latitude = 52.2335m,
                    Longitude = 21.0225m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-36),
                    SpeedKph = 0m,
                    HeadingDeg = 0m,
                    Ignition = false
                },
                new GeoDataViewModel
                {
                    Id = 9,
                    CarId = 1,
                    Latitude = 52.2340m,
                    Longitude = 21.0250m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-34),
                    SpeedKph = 55m,
                    HeadingDeg = 110m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 10,
                    CarId = 1,
                    Latitude = 52.2350m,
                    Longitude = 21.0280m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-32),
                    SpeedKph = 60m,
                    HeadingDeg = 115m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 11,
                    CarId = 1,
                    Latitude = 52.2360m,
                    Longitude = 21.0310m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-30),
                    SpeedKph = 65m,
                    HeadingDeg = 120m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 12,
                    CarId = 1,
                    Latitude = 52.2370m,
                    Longitude = 21.0340m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-28),
                    SpeedKph = 70m,
                    HeadingDeg = 125m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 13,
                    CarId = 2,
                    Latitude = 50.0614m,
                    Longitude = 19.9366m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-60),
                    SpeedKph = 25m,
                    HeadingDeg = 180m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 14,
                    CarId = 2,
                    Latitude = 50.0620m,
                    Longitude = 19.9400m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-58),
                    SpeedKph = 35m,
                    HeadingDeg = 182m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 15,
                    CarId = 2,
                    Latitude = 50.0622m,
                    Longitude = 19.9405m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-56),
                    SpeedKph = 0m,
                    HeadingDeg = 0m,
                    Ignition = false
                },
                new GeoDataViewModel
                {
                    Id = 16,
                    CarId = 2,
                    Latitude = 50.0622m,
                    Longitude = 19.9405m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-54),
                    SpeedKph = 0m,
                    HeadingDeg = 0m,
                    Ignition = false
                },
                new GeoDataViewModel
                {
                    Id = 17,
                    CarId = 2,
                    Latitude = 50.0630m,
                    Longitude = 19.9430m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-52),
                    SpeedKph = 45m,
                    HeadingDeg = 190m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 18,
                    CarId = 2,
                    Latitude = 50.0640m,
                    Longitude = 19.9460m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-50),
                    SpeedKph = 50m,
                    HeadingDeg = 193m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 19,
                    CarId = 2,
                    Latitude = 50.0650m,
                    Longitude = 19.9490m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-48),
                    SpeedKph = 55m,
                    HeadingDeg = 195m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 20,
                    CarId = 2,
                    Latitude = 50.0652m,
                    Longitude = 19.9495m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-46),
                    SpeedKph = 0m,
                    HeadingDeg = 0m,
                    Ignition = false
                },
                new GeoDataViewModel
                {
                    Id = 21,
                    CarId = 2,
                    Latitude = 50.0660m,
                    Longitude = 19.9520m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-44),
                    SpeedKph = 60m,
                    HeadingDeg = 200m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 22,
                    CarId = 2,
                    Latitude = 50.0670m,
                    Longitude = 19.9550m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-42),
                    SpeedKph = 65m,
                    HeadingDeg = 202m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 23,
                    CarId = 3,
                    Latitude = 51.1079m,
                    Longitude = 17.0385m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-70),
                    SpeedKph = 20m,
                    HeadingDeg = 160m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 24,
                    CarId = 3,
                    Latitude = 51.1085m,
                    Longitude = 17.0410m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-68),
                    SpeedKph = 30m,
                    HeadingDeg = 165m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 25,
                    CarId = 3,
                    Latitude = 51.1090m,
                    Longitude = 17.0435m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-66),
                    SpeedKph = 35m,
                    HeadingDeg = 170m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 26,
                    CarId = 3,
                    Latitude = 51.1092m,
                    Longitude = 17.0438m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-64),
                    SpeedKph = 0m,
                    HeadingDeg = 0m,
                    Ignition = false
                },
                new GeoDataViewModel
                {
                    Id = 27,
                    CarId = 3,
                    Latitude = 51.1092m,
                    Longitude = 17.0438m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-62),
                    SpeedKph = 0m,
                    HeadingDeg = 0m,
                    Ignition = false
                },
                new GeoDataViewModel
                {
                    Id = 28,
                    CarId = 3,
                    Latitude = 51.1100m,
                    Longitude = 17.0460m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-60),
                    SpeedKph = 40m,
                    HeadingDeg = 175m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 29,
                    CarId = 3,
                    Latitude = 51.1110m,
                    Longitude = 17.0485m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-58),
                    SpeedKph = 45m,
                    HeadingDeg = 178m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 30,
                    CarId = 3,
                    Latitude = 51.1120m,
                    Longitude = 17.0510m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-56),
                    SpeedKph = 50m,
                    HeadingDeg = 180m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 31,
                    CarId = 3,
                    Latitude = 51.1122m,
                    Longitude = 17.0512m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-54),
                    SpeedKph = 0m,
                    HeadingDeg = 0m,
                    Ignition = false
                },
                new GeoDataViewModel
                {
                    Id = 32,
                    CarId = 3,
                    Latitude = 51.1130m,
                    Longitude = 17.0530m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-52),
                    SpeedKph = 55m,
                    HeadingDeg = 185m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 33,
                    CarId = 4,
                    Latitude = 52.2297m,
                    Longitude = 21.0122m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-90),
                    SpeedKph = 30m,
                    HeadingDeg = 120m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 34,
                    CarId = 4,
                    Latitude = 52.2302m,
                    Longitude = 21.0140m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-88),
                    SpeedKph = 40m,
                    HeadingDeg = 125m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 35,
                    CarId = 4,
                    Latitude = 52.2310m,
                    Longitude = 21.0165m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-86),
                    SpeedKph = 45m,
                    HeadingDeg = 130m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 36,
                    CarId = 4,
                    Latitude = 52.2312m,
                    Longitude = 21.0168m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-84),
                    SpeedKph = 0m,
                    HeadingDeg = 0m,
                    Ignition = false
                },
                new GeoDataViewModel
                {
                    Id = 37,
                    CarId = 4,
                    Latitude = 52.2312m,
                    Longitude = 21.0168m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-82),
                    SpeedKph = 0m,
                    HeadingDeg = 0m,
                    Ignition = false
                },
                new GeoDataViewModel
                {
                    Id = 38,
                    CarId = 4,
                    Latitude = 52.2320m,
                    Longitude = 21.0190m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-80),
                    SpeedKph = 35m,
                    HeadingDeg = 135m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 39,
                    CarId = 4,
                    Latitude = 52.2330m,
                    Longitude = 21.0215m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-78),
                    SpeedKph = 50m,
                    HeadingDeg = 140m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 40,
                    CarId = 4,
                    Latitude = 52.2340m,
                    Longitude = 21.0240m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-76),
                    SpeedKph = 55m,
                    HeadingDeg = 145m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 41,
                    CarId = 4,
                    Latitude = 52.2342m,
                    Longitude = 21.0243m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-74),
                    SpeedKph = 0m,
                    HeadingDeg = 0m,
                    Ignition = false
                },
                new GeoDataViewModel
                {
                    Id = 42,
                    CarId = 4,
                    Latitude = 52.2350m,
                    Longitude = 21.0260m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-72),
                    SpeedKph = 60m,
                    HeadingDeg = 150m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 43,
                    CarId = 5,
                    Latitude = 50.0647m,
                    Longitude = 19.9450m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-50),
                    SpeedKph = 25m,
                    HeadingDeg = 90m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 44,
                    CarId = 5,
                    Latitude = 50.0652m,
                    Longitude = 19.9470m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-48),
                    SpeedKph = 35m,
                    HeadingDeg = 95m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 45,
                    CarId = 5,
                    Latitude = 50.0660m,
                    Longitude = 19.9495m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-46),
                    SpeedKph = 40m,
                    HeadingDeg = 100m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 46,
                    CarId = 5,
                    Latitude = 50.0662m,
                    Longitude = 19.9498m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-44),
                    SpeedKph = 0m,
                    HeadingDeg = 0m,
                    Ignition = false
                },
                new GeoDataViewModel
                {
                    Id = 47,
                    CarId = 5,
                    Latitude = 50.0662m,
                    Longitude = 19.9498m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-42),
                    SpeedKph = 0m,
                    HeadingDeg = 0m,
                    Ignition = false
                },
                new GeoDataViewModel
                {
                    Id = 48,
                    CarId = 5,
                    Latitude = 50.0670m,
                    Longitude = 19.9520m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-40),
                    SpeedKph = 45m,
                    HeadingDeg = 105m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 49,
                    CarId = 5,
                    Latitude = 50.0680m,
                    Longitude = 19.9545m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-38),
                    SpeedKph = 50m,
                    HeadingDeg = 110m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 50,
                    CarId = 5,
                    Latitude = 50.0690m,
                    Longitude = 19.9570m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-36),
                    SpeedKph = 55m,
                    HeadingDeg = 115m,
                    Ignition = true
                },
                new GeoDataViewModel
                {
                    Id = 51,
                    CarId = 5,
                    Latitude = 50.0692m,
                    Longitude = 19.9573m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-34),
                    SpeedKph = 0m,
                    HeadingDeg = 0m,
                    Ignition = false
                },
                new GeoDataViewModel
                {
                    Id = 52,
                    CarId = 5,
                    Latitude = 50.0700m,
                    Longitude = 19.9590m,
                    RecordedAt = DateTime.UtcNow.AddMinutes(-32),
                    SpeedKph = 60m,
                    HeadingDeg = 120m,
                    Ignition = true
                }
            };
            
            var filteredPoints = geoDataPoints.Where(point => point.CarId == id).ToList();
    
            if (!filteredPoints.Any())
            {
                filteredPoints = [];
            }

            return Ok(filteredPoints);

        }
    }
}

