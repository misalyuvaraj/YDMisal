using Microsoft.EntityFrameworkCore;
using YDMisal.API.Data;
using YDMisal.API.Models.Domain;

namespace YDMisal.API.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        public RegionRepository(NZWalksDbContext nZWalksDbContext)
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public IEnumerable<Region> GetAllAsync()
        {
           
            return nZWalksDbContext.Regions.ToList();
        }
    }
}
