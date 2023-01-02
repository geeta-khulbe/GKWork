using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Models.Domain;

namespace WebApplicationAPI.Data
{
    public class GKWalksDBContext : DbContext
    {
        public GKWalksDBContext(DbContextOptions<GKWalksDBContext> options) : base(options)
        {

        }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulties { get; set; }
    }
}
