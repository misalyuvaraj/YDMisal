using YDMisal.API.Models.Domain;

namespace YDMisal.API.Repository
{
    // Interface that defines what operations the Walk repository must support
    public interface IWalkRepository
    {
        // Get all walks from the database
        Task<IEnumerable<Walk>> GetAllAsync();

        // Get a single walk by its ID (returns null if not found)
        Task<Walk?> GetAsync(Guid id);

        // Add a new walk to the database
        Task<Walk> AddAsync(Walk walk);

        // Update an existing walk by ID (returns null if not found)
        Task<Walk?> UpdateAsync(Guid id, Walk walk);

        // Delete a walk by ID (returns null if not found)
        Task<Walk?> DeleteAsync(Guid id);
    }
}
