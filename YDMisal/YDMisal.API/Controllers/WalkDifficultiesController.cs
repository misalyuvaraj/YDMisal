using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YDMisal.API.Repository;

namespace YDMisal.API.Controllers
{
    // Handles all API requests related to Walk Difficulties (CRUD operations)
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultiesController : Controller
    {
        // Used to access walk difficulty data from the database
        private readonly IWalkDifficultyRepository walkDifficultyRepository;

        // Used to convert domain models to DTOs
        private readonly IMapper mapper;

        // Constructor — injects the repository and mapper
        public WalkDifficultiesController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {
            this.walkDifficultyRepository = walkDifficultyRepository;
            this.mapper = mapper;
        }

        // GET: /WalkDifficulties — returns all difficulty levels
        [HttpGet]
        public async Task<IActionResult> GetAllWalkDifficulties()
        {
            var walkDifficultiesDomain = await walkDifficultyRepository.GetAllAsync();
            var walkDifficultyDTO = mapper.Map<List<Models.DTO.WalkDifficulty>>(walkDifficultiesDomain);
            return Ok(walkDifficultyDTO);
        }

        // GET: /WalkDifficulties/{id} — returns a single difficulty level by ID
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetWalkDifficultyById(Guid id)
        {
            var walkDifficulty = await walkDifficultyRepository.GetAsync(id);

            // Return 404 if not found
            if (walkDifficulty == null)
            {
                return NotFound();
            }

            var walkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficulty);
            return Ok(walkDifficultyDTO);
        }

        // POST: /WalkDifficulties — creates a new difficulty level
        [HttpPost]
        public async Task<IActionResult> AddWalkDifficultyAsync(
            Models.DTO.AddWalkDifficultyRequest addWalkDifficultyRequest)
        {
            // FluentValidation runs automatically via [ApiController] + AddFluentValidationAutoValidation()

            // Map request to domain model
            var walkDifficultyDomain = new Models.Domain.WalkDifficulty
            {
                Code = addWalkDifficultyRequest.Code
            };

            walkDifficultyDomain = await walkDifficultyRepository.AddAsync(walkDifficultyDomain);

            // Convert saved domain model back to DTO
            var walkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficultyDomain);

            // Return 201 Created with location header
            return CreatedAtAction(nameof(GetWalkDifficultyById), new { id = walkDifficultyDTO.Id }, walkDifficultyDTO);
        }

        // PUT: /WalkDifficulties/{id} — updates an existing difficulty level
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkDifficultyAsync(Guid id,
            Models.DTO.UpdateWalkDifficultyRequest updateWalkDifficultyRequest)
        {
            // FluentValidation runs automatically via [ApiController] + AddFluentValidationAutoValidation()

            // Map request to domain model
            var walkDifficultyDomain = new Models.Domain.WalkDifficulty
            {
                Code = updateWalkDifficultyRequest.Code
            };

            walkDifficultyDomain = await walkDifficultyRepository.UpdateAsync(id, walkDifficultyDomain);

            // Return 404 if not found
            if (walkDifficultyDomain == null)
            {
                return NotFound();
            }

            var walkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficultyDomain);
            return Ok(walkDifficultyDTO);
        }

        // DELETE: /WalkDifficulties/{id} — deletes a difficulty level by ID
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkDifficulty(Guid id)
        {
            var walkDifficultyDomain = await walkDifficultyRepository.DeleteAsync(id);

            // Return 404 if not found
            if (walkDifficultyDomain == null)
            {
                return NotFound();
            }

            var walkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficulty>(walkDifficultyDomain);
            return Ok(walkDifficultyDTO);
        }
    }
}
