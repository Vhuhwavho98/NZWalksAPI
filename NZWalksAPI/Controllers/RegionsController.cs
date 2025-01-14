using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

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
            var regionsDto = new List<RegionDTO>();
            foreach (var region in regions)
            {
                regionsDto.Add(new RegionDTO()
                {
                    Id = region.Id,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl,
                    Code = region.Code,

                });
            }
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

            var regionDto = new RegionDTO
            {
                Id = region.Id,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl,
                Code = region.Code,

            };

            return Ok(regionDto);
        }


        [HttpPost]
        public IActionResult CreateRegion([FromBody] AddRegionRequest addRegionRequest)
        {
            var regionDomainModel = new Region
            {
                Code = addRegionRequest.Code,
                RegionImageUrl = addRegionRequest.RegionImageUrl,
                Name = addRegionRequest.Name,
            };

            _nZWalksDbContext.regions.Add(regionDomainModel);
            _nZWalksDbContext.SaveChanges();


            var regionDto = new RegionDTO
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl,
                Code = regionDomainModel.Code,
            };

            return CreatedAtAction(nameof(GetRegionById), new {id = regionDto.Id}, regionDto);

        }
    }
}
