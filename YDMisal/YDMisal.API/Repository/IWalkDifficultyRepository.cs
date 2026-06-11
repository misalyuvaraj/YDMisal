using YDMisal.API.Models.Domain;

namespace YDMisal.API.Repository
{
    // Interface that defines what operations the WalkDifficulty repository must support
    public interface IWalkDifficultyRepository
    {
        // Get all difficulty levels from the database
        Task<IEnumerable<WalkDifficulty>> GetAllAsync();

        // Get a single difficulty level by its ID
        Task<WalkDifficulty> GetAsync(Guid id);

        // Add a new difficulty level to the database
        Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty);

        // Update an existing difficulty level by ID
        Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkDifficulty);

        // Delete a difficulty level by ID
        Task<WalkDifficulty> DeleteAsync(Guid id);
    }
}
