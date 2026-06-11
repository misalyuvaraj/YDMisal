using Microsoft.EntityFrameworkCore;
using YDMisal.API.Data;
using YDMisal.API.Models.Domain;

namespace YDMisal.API.Repository
{
    // Handles all database operations for regions
    public class RegionRepository : IRegionRepository
    {
        // Database context used to talk to SQL Server
        private readonly NZWalksDbContext nZWalksDbContext;

        // Constructor — injects the database context
        public RegionRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        // Add a new region to the database
        public async Task<Region> AddAsync(Region region)
        {
            // Generate a new unique ID before saving
            region.Id = Guid.NewGuid();

            await nZWalksDbContext.AddAsync(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        // Delete a region by its ID
        public async Task<Region?> DeleteAsync(Guid id)
        {
            // First find the region — return null if it doesn't exist
            var region = await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
            {
                return null;
            }

            // Remove it and save changes
            nZWalksDbContext.Regions.Remove(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        // Get all regions from the database
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await nZWalksDbContext.Regions.ToListAsync();
        }

        // Get a single region by ID
        public async Task<Region?> GetAsync(Guid id)
        {
            return await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        // Update an existing region's details
        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            // Find the existing region first
            var existingRegion = await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }

            // Update each field with new values
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Area = region.Area;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;

            await nZWalksDbContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
