using Microsoft.EntityFrameworkCore;
using YDMisal.API.Data;
using YDMisal.API.Models.Domain;

namespace YDMisal.API.Repository
{
    // Handles all database operations for walk difficulty levels
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        // Database context used to talk to SQL Server
        private readonly NZWalksDbContext nZWalksDbContext;

        // Constructor — injects the database context
        public WalkDifficultyRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        // Get all difficulty levels from the database
        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await nZWalksDbContext.WalkDifficulty.ToListAsync();
        }

        // Get a single difficulty level by ID
        public async Task<WalkDifficulty> GetAsync(Guid id)
        {
            return await nZWalksDbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);
        }

        // Add a new difficulty level to the database
        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty)
        {
            // Generate a new unique ID before saving
            walkDifficulty.Id = Guid.NewGuid();

            await nZWalksDbContext.WalkDifficulty.AddAsync(walkDifficulty);
            await nZWalksDbContext.SaveChangesAsync();
            return walkDifficulty;
        }

        // Update an existing difficulty level's code
        public async Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkDifficulty)
        {
            var existingWalkDifficulty = await nZWalksDbContext.WalkDifficulty.FindAsync(id);
            if (existingWalkDifficulty == null)
            {
                return null;
            }

            existingWalkDifficulty.Code = walkDifficulty.Code;
            await nZWalksDbContext.SaveChangesAsync();
            return existingWalkDifficulty;
        }

        // Delete a difficulty level by ID
        public async Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            var existingWalkDifficulty = await nZWalksDbContext.WalkDifficulty.FindAsync(id);
            if (existingWalkDifficulty != null)
            {
                nZWalksDbContext.WalkDifficulty.Remove(existingWalkDifficulty);
                await nZWalksDbContext.SaveChangesAsync();
                return existingWalkDifficulty;
            }
            return null;
        }
    }
}
