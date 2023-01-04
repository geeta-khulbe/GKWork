using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Data;
using WebApplicationAPI.Models.Domain;

namespace WebApplicationAPI.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly GKWalksDBContext gKWalksDBContext;
        public RegionRepository(GKWalksDBContext gkWalksDBContext)
        {
            this.gKWalksDBContext = gkWalksDBContext;
        }

        public GKWalksDBContext GKWalksDBContext { get; }

        public async  Task<IEnumerable<Region>> GetAllAsyn()
        {
            return await gKWalksDBContext.Regions.ToListAsync();
            //throw new NotImplementedException();
        }
    }
}
