using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YDMisal.API.Repository;

namespace YDMisal.API.Controllers
{
    // Handles all API requests related to Walks (CRUD operations)
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        // Used to access walk data from the database
        private readonly IWalkRepository walkRepository;

        // Used to convert domain models to DTOs
        private readonly IMapper mapper;

        // Constructor — injects the repository and mapper
        public WalksController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        // GET: /Walks — returns all walks
        [HttpGet]
        public async Task<IActionResult> GetAllWalksAsync()
        {
            var walksDomain = await walkRepository.GetAllAsync();

            // Convert domain models to DTOs before returning
            var walksDTO = mapper.Map<List<Models.DTO.Walk>>(walksDomain);
            return Ok(walksDTO);
        }

        // GET: /Walks/{id} — returns a single walk by ID
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkAsync")]
        public async Task<IActionResult> GetWalkAsync(Guid id)
        {
            var walkDomain = await walkRepository.GetAsync(id);

            // Return 404 if not found
            if (walkDomain == null)
            {
                return NotFound();
            }

            var walkDTO = mapper.Map<Models.DTO.Walk>(walkDomain);
            return Ok(walkDTO);
        }

        // POST: /Walks — creates a new walk
        [HttpPost]
        public async Task<IActionResult> AddWalkAsync([FromBody] Models.DTO.AddWalkRequest addWalkRequest)
        {
            // FluentValidation runs automatically via [ApiController] + AddFluentValidationAutoValidation()

            // Map the request DTO to a domain model
            var walkDomain = new Models.Domain.Walk
            {
                Lenght = addWalkRequest.Lenght,
                Name = addWalkRequest.Name,
                RegionId = addWalkRequest.RegionId,
                WalkDifficultyId = addWalkRequest.WalkDifficultyId
            };

            var savedWalk = await walkRepository.AddAsync(walkDomain);

            // Convert saved domain model back to DTO
            var walkDTO = mapper.Map<Models.DTO.Walk>(savedWalk);

            // Return 201 Created with location header
            return CreatedAtAction(nameof(GetWalkAsync), new { id = walkDTO.Id }, walkDTO);
        }

        // PUT: /Walks/{id} — updates an existing walk
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkAsync(Guid id,
            [FromBody] Models.DTO.UpdateWalkRequest updateWalkRequest)
        {
            // FluentValidation runs automatically via [ApiController] + AddFluentValidationAutoValidation()

            // Map the request DTO to a domain model
            var walkDomain = new Models.Domain.Walk
            {
                Lenght = updateWalkRequest.Lenght,
                Name = updateWalkRequest.Name,
                RegionId = updateWalkRequest.RegionId,
                WalkDifficultyId = updateWalkRequest.WalkDifficultyId
            };

            var updatedWalk = await walkRepository.UpdateAsync(id, walkDomain);

            // Return 404 if walk doesn't exist
            if (updatedWalk == null)
            {
                return NotFound();
            }

            var walkDTO = mapper.Map<Models.DTO.Walk>(updatedWalk);
            return Ok(walkDTO);
        }

        // DELETE: /Walks/{id} — deletes a walk by ID
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkAsync(Guid id)
        {
            var walkDomain = await walkRepository.DeleteAsync(id);

            // Return 404 if not found
            if (walkDomain == null)
            {
                return NotFound();
            }

            var walkDTO = mapper.Map<Models.DTO.Walk>(walkDomain);
            return Ok(walkDTO);
        }
    }
}
