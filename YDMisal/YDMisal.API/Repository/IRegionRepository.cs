using YDMisal.API.Models.Domain;

namespace YDMisal.API.Repository
{
    // Interface that defines what operations the Region repository must support
    // Any class that implements this must provide these methods
    public interface IRegionRepository
    {
        // Get all regions from the database
        Task<IEnumerable<Region>> GetAllAsync();

        // Get a single region by its ID (returns null if not found)
        Task<Region?> GetAsync(Guid id);

        // Add a new region to the database
        Task<Region> AddAsync(Region region);

        // Update an existing region by ID (returns null if not found)
        Task<Region?> UpdateAsync(Guid id, Region region);

        // Delete a region by ID (returns null if not found)
        Task<Region?> DeleteAsync(Guid id);
    }
}
