using Microsoft.EntityFrameworkCore;
using YDMisal.API.Models.Domain;

namespace YDMisal.API.Data
{
    // This is the database context — it connects the app to SQL Server
    // Think of it as the "gateway" to the database
    public class NZWalksDbContext : DbContext
    {
        // Constructor receives database configuration from Program.cs
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options) : base(options)
        {
        }

        // Represents the Regions table in the database
        public DbSet<Region> Regions { get; set; }

        // Represents the Walk table in the database
        public DbSet<Walk> Walk { get; set; }

        // Represents the WalkDifficulty table in the database
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }
    }
}
