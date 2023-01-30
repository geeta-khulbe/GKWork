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

        public async  Task<Region> AddAsyn(Region region)
        {
            region.Id = new Guid();
            await gKWalksDBContext.AddAsync(region);
            await gKWalksDBContext.SaveChangesAsync();
            return region;
        }

        public async Task<Boolean> DeleteAsync(Guid id)
        {
            var region = await gKWalksDBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
                return false;
            gKWalksDBContext.Regions.Remove(region);
            await gKWalksDBContext.SaveChangesAsync();
            return true;
        }

        public async  Task<IEnumerable<Region>> GetAllAsyn()
        {
            return await gKWalksDBContext.Regions.ToListAsync();
            //throw new NotImplementedException();
        }

        public async Task<Region> GetAsyn(Guid id)
        {
            return await gKWalksDBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);   
        }

        public async Task<Region> UpdateAsync(Guid id,Region region)
        {
            var data = await gKWalksDBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
                return null;
            data.Name = region.Name;
            data.Code = data.Code;
            await gKWalksDBContext.SaveChangesAsync();
            return data;
        }
    }
}
