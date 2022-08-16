using Iter0_Backend.Data.Entities;

namespace Iter0_Backend.Data.Repository
{
    public interface IAppRepository
    {
        //Kids
        Task<IEnumerable<KidEntity>> GetKidsAsync();
    }
}