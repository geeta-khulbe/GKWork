using WebApplicationAPI.Models.Domain;

namespace WebApplicationAPI.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsyn();
    }
}
