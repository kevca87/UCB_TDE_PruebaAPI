using Iter0_Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Iter0_Backend.Data.Repository
{
    public class AppRepository : IAppRepository
    {
        private AppDBContext _dbContext;
        private readonly IConfiguration Configuration;
        public AppRepository(AppDBContext dBContext, IConfiguration configuration)
        {
            Configuration = configuration;
            _dbContext = dBContext;
        }
        public async Task<IEnumerable<KidEntity>> GetKidsAsync()
        {

            IQueryable<KidEntity> query = _dbContext.Kids;
            query = query.AsNoTracking();
            return await query.ToListAsync();
        }

        public KidEntity CreateKid(KidEntity kid)
        {
            _dbContext.Kids.Add(kid);
            return kid;
        }
        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                var result = await _dbContext.SaveChangesAsync();
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
