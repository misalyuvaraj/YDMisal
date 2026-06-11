using Microsoft.EntityFrameworkCore;
using YDMisal.API.Data;
using YDMisal.API.Models.Domain;

namespace YDMisal.API.Repository
{
    // Handles all database operations for walks
    // Also loads related Region and WalkDifficulty data automatically (eager loading)
    public class WalkRepository : IWalkRepository
    {
        // Database context used to talk to SQL Server
        private readonly NZWalksDbContext nZWalksDbContext;

        // Constructor — injects the database context
        public WalkRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        // Add a new walk to the database
        public async Task<Walk> AddAsync(Walk walk)
        {
            // Generate a new unique ID before saving
            walk.Id = Guid.NewGuid();

            await nZWalksDbContext.Walk.AddAsync(walk);
            await nZWalksDbContext.SaveChangesAsync();
            return walk;
        }

        // Delete a walk by its ID
        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await nZWalksDbContext.Walk.FindAsync(id);
            if (existingWalk == null)
            {
                return null;
            }

            nZWalksDbContext.Walk.Remove(existingWalk);
            await nZWalksDbContext.SaveChangesAsync();
            return existingWalk;
        }

        // Get all walks, including their Region and WalkDifficulty details
        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await
                nZWalksDbContext.Walk
                .Include(x => x.Region)           // Load region info
                .Include(x => x.WalkDifficulty)   // Load difficulty info
                .ToListAsync();
        }

        // Get a single walk by ID, including related data
        public async Task<Walk?> GetAsync(Guid id)
        {
            return await nZWalksDbContext.Walk
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        // Update an existing walk's details
        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await nZWalksDbContext.Walk.FindAsync(id);
            if (existingWalk == null)
            {
                return null;
            }

            // Update each field with new values
            existingWalk.Lenght = walk.Lenght;
            existingWalk.Name = walk.Name;
            existingWalk.WalkDifficultyId = walk.WalkDifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await nZWalksDbContext.SaveChangesAsync();
            return existingWalk;
        }
    }
}
