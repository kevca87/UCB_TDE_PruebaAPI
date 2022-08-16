using Iter0_Backend.Data.Entities;
using Iter0_Backend.Models;

namespace Iter0_Backend.Services
{
    public interface IKidService
    {
        Task<IEnumerable<KidModel>> GetKidsAsync();
        Task<KidModel> CreateKidAsync(KidModel kid);
    }
}
