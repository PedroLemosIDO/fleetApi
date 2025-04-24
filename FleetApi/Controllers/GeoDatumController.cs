using FleetApi.Models.Database.Gps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FleetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoDatumController : ControllerBase
    {
        private readonly InternsqlContext _internsqlContext;

        private readonly ILogger<GeoDatumController> _logger;

        public GeoDatumController(ILogger<GeoDatumController> logger, InternsqlContext context)
        {
            _logger = logger;
            _internsqlContext = context;
        }

        [HttpGet(Name = "GetGeoData")]
        public IActionResult Get(int id)
        {
            var geoD = _internsqlContext.GeoData.Find(id);

            if (geoD == null)
            {
                return NotFound();
            }
            return Ok(geoD);
        }

        [Route("GetGeoDataByCarId", Name = "GetGeoDataByCarId")]
        [HttpGet]
        public IActionResult GetByCarId(int carId)
        {
            var geoD = _internsqlContext.GeoData.Find(carId);

            if (geoD == null)
            {
                return NotFound();
            }
            return Ok(geoD);
        }

        [Route("GetGeoDataByLat", Name = "GetGeoDataByLat")]
        [HttpGet]
        public IActionResult GetByLat(decimal lat)
        {
            var geoD = _internsqlContext.GeoData.Where(latTmp => latTmp.Latitude.Equals(lat)).FirstOrDefault();

            if (geoD == null)
            {
                return NotFound();
            }
            return Ok(geoD);
        }

        [Route("GetGeoDataByLon", Name = "GetGeoDataByLon")]
        [HttpGet]
        public IActionResult GetByLon(decimal lon)
        {
            var geoD = _internsqlContext.GeoData.Where(lonTmp => lonTmp.Longitude.Equals(lon)).FirstOrDefault();

            if (geoD == null)
            {
                return NotFound();
            }
            return Ok(geoD);
        }

        [Route("GetGeoDataBySpeedKph", Name = "GetGeoDataBySpeedKph")]
        [HttpGet]
        public IActionResult GetBySpeedKph(decimal speed)
        {
            var geoD = _internsqlContext.GeoData.Where(speedTmp => speedTmp.SpeedKph.Equals(speed)).FirstOrDefault();

            if (geoD == null)
            {
                return NotFound();
            }
            return Ok(geoD);
        }

        [Route("GetGeoDataByHeadingDeg", Name = "GetGeoDataByHeadingDeg")]
        [HttpGet]
        public IActionResult GetByHeadingDeg(decimal headingDeg)
        {
            var geoD = _internsqlContext.GeoData.Where(headTmp => headTmp.HeadingDeg.Equals(headingDeg)).FirstOrDefault();

            if (geoD == null)
            {
                return NotFound();
            }
            return Ok(geoD);
        }

        [Route("GetGeoDataByLatest", Name = "GetGeoDataByLatest")]
        [HttpGet]
        public IActionResult GetGeoDataByLatest()
        {
            var geoDlist = _internsqlContext.GeoData.ToList();

            List<GeoDatum> eachLocal = new List<GeoDatum>();
            List<int> eachId = new List<int>();

            foreach(var geo in geoDlist)
            {
                if (!eachId.Contains(geo.CarId))
                {
                    eachLocal.Add(geoDlist.FindLast(elem => elem.CarId == geo.CarId));
                    eachId.Add(geo.CarId);
                }
            }

            if (eachLocal == null)
            {
                return NotFound();
            }
            return Ok(eachLocal);
        }

        [Route("GetGeoDataAll", Name = "GetGeoDataAll")]
        [HttpGet]
        public IActionResult GetGeoDataAll()
        {
            var brands = _internsqlContext.GeoData.ToList();

            if (brands == null)
            {
                return NotFound();
            }
            return Ok(brands);
        }
        
        [Route("GetGeoDataByCarIdAll", Name = "GetGeoDataByCarIdAll")]
        [HttpGet]
        public IActionResult GetGeoDataByCarIdAll(int id)
        {
            var geoData = _internsqlContext.GeoData.Where(data => data.CarId.Equals(id)).OrderBy(data => data.RecordedAt).ToList();

            if (geoData == null)
            {
                return NotFound();
            }
            return Ok(geoData);
        }
    }
}
