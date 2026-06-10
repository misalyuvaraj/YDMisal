using YDMisal.API.Models.Domain;

namespace YDMisal.API.Repository
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetAllAsync();
    }
}
