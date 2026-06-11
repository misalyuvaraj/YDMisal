using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YDMisal.API.Models.DTO;
using YDMisal.API.Repository;

namespace YDMisal.API.Controllers
{
    // Handles all API requests related to Regions (CRUD operations)
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        // Used to access region data from the database
        private readonly IRegionRepository regionRepository;

        // Used to convert domain models to DTOs and vice versa
        private readonly IMapper mapper;

        // Constructor — injects the repository and mapper
        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        // GET: /Regions — returns all regions
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionRepository.GetAllAsync();

            // Convert domain models to DTOs before returning
            var regionsDTO = mapper.Map<List<Region>>(regions);

            return Ok(regionsDTO);
        }

        // GET: /Regions/{id} — returns a single region by ID
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionRepository.GetAsync(id);

            // Return 404 if region not found
            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = mapper.Map<Region>(region);

            return Ok(regionDTO);
        }

        // POST: /Regions — creates a new region
        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(AddRegionRequest addRegionRequest)
        {
            // FluentValidation runs automatically via [ApiController] + AddFluentValidationAutoValidation()

            // Map the incoming request to a domain model
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

            // Convert saved domain model back to DTO for the response
            var regionDto = mapper.Map<Region>(savedRegion);

            // Return 201 Created with location header pointing to the new resource
            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDto.Id }, regionDto);
        }

        // PUT: /Regions/{id} — updates an existing region
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync(Guid id, UpdateRegionRequest updateRegionRequest)
        {
            // FluentValidation runs automatically via [ApiController] + AddFluentValidationAutoValidation()

            // Map the incoming request to a domain model
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

            // Return 404 if region doesn't exist
            if (updatedRegion == null)
            {
                return NotFound();
            }

            var regionDto = mapper.Map<Region>(updatedRegion);

            return Ok(regionDto);
        }

        // DELETE: /Regions/{id} — deletes a region by ID
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsync(Guid id)
        {
            var deletedRegion = await regionRepository.DeleteAsync(id);

            // Return 404 if region doesn't exist
            if (deletedRegion == null)
            {
                return NotFound();
            }

            // Return the deleted region in the response
            var regionDto = mapper.Map<Region>(deletedRegion);

            return Ok(regionDto);
        }
    }
}
