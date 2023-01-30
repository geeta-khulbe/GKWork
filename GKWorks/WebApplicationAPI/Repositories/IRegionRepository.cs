using WebApplicationAPI.Models.Domain;

namespace WebApplicationAPI.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsyn();
        Task<Region> GetAsyn(Guid id);
        Task<Region> AddAsyn(Region region);
        Task<Boolean> DeleteAsync(Guid id);
        Task<Region> UpdateAsync(Guid id ,Region region);
    }
}
