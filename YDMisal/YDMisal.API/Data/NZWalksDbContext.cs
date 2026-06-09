using Microsoft.EntityFrameworkCore;
using YDMisal.API.Models.Domain;

namespace YDMisal.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options) : base(options)
        {
            
        }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walk { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }

    }
}
