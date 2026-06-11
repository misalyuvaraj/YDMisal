using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YDMisal.API.Models.DTO;
using YDMisal.API.Repository;

namespace YDMisal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        // GET: /Regions
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionRepository.GetAllAsync();
            var regionsDTO = mapper.Map<List<Region>>(regions);

            return Ok(regionsDTO);
        }

        // GET: /Regions/{id}
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionRepository.GetAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = mapper.Map<Region>(region);

            return Ok(regionDTO);
        }

        // POST: /Regions
        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(AddRegionRequest addRegionRequest)
        {
            // FluentValidation runs automatically via [ApiController] + AddFluentValidationAutoValidation()
            var regionDomain = new Models.Domain.Region()
            {
                Code = addRegionRequest.Code,
                Name = addRegionRequest.Name,
                Area = addRegionRequest.Area,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Population = addRegionRequest.Population
            };

            var savedRegion = await regionRepository.AddAsync(regionDomain);
            var regionDto = mapper.Map<Region>(savedRegion);

            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDto.Id }, regionDto);
        }

        // PUT: /Regions/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync(Guid id, UpdateRegionRequest updateRegionRequest)
        {
            // FluentValidation runs automatically via [ApiController] + AddFluentValidationAutoValidation()
            var regionDomain = new Models.Domain.Region()
            {
                Code = updateRegionRequest.Code,
                Name = updateRegionRequest.Name,
                Area = updateRegionRequest.Area,
                Lat = updateRegionRequest.Lat,
                Long = updateRegionRequest.Long,
                Population = updateRegionRequest.Population
            };

            var updatedRegion = await regionRepository.UpdateAsync(id, regionDomain);

            if (updatedRegion == null)
            {
                return NotFound();
            }

            var regionDto = mapper.Map<Region>(updatedRegion);

            return Ok(regionDto);
        }

        // DELETE: /Regions/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var deletedRegion = await regionRepository.DeleteAsync(id);

            if (deletedRegion == null)
            {
                return NotFound();
            }

            var regionDto = mapper.Map<Region>(deletedRegion);

            return Ok(regionDto);
        }
    }
}
