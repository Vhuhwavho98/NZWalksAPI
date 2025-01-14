using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _nZWalksDbContext;

        public RegionsController( NZWalksDbContext nZWalksDbContext)
        {
            _nZWalksDbContext = nZWalksDbContext;
        }
        [HttpGet]
        public IActionResult GetAllRegions()
        {

            var regions = _nZWalksDbContext.regions.ToList();
            return Ok(regions);
        }

        [HttpGet("{id}")]
        public IActionResult GetRegionById(Guid id)
        {
            var region = _nZWalksDbContext.regions.Find(id);

            if(region == null)
            {
                return NotFound();
            }

            return Ok(region);
        }
    }
}
