using FleetApi.Models.Database.Gps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FleetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsModelController : ControllerBase
    {
        private readonly InternsqlContext _internsqlContext;

        private readonly ILogger<BrandsModelController> _logger;

        public BrandsModelController(ILogger<BrandsModelController> logger, InternsqlContext context)
        {
            _logger = logger;
            _internsqlContext = context;
        }

        [HttpGet(Name = "GetBrand")]
        public IActionResult Get(int id)
        {
            var brand = _internsqlContext.BrandsModels.Find(id);

            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        [Route("GetBrandByName", Name = "GetBrandByName")]
        [HttpGet]
        public IActionResult GetByName(string name)
        {
            var brand = _internsqlContext.BrandsModels.Where(brandTmp => brandTmp.BrandName.Equals(name)).FirstOrDefault();

            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        [Route("GetBrandByModel", Name = "GetBrandByModel")]
        [HttpGet]
        public IActionResult GetByModel(string name)
        {
            var model = _internsqlContext.BrandsModels.Where(brandTmp => brandTmp.ModelName.Equals(name)).FirstOrDefault();

            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [Route("GetBrands", Name = "GetBrands")]
        [HttpGet]
        public IActionResult GetBrands()
        {
            var brands = _internsqlContext.BrandsModels.ToList();

            if (brands == null)
            {
                return NotFound();
            }
            return Ok(brands);
        }
    }
}
