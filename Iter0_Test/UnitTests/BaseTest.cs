using Iter0_Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iter0_Test.UnitTests
{
    public class BaseTest
    {
        protected AppDBContext ctx;
        public BaseTest(AppDBContext ctx = null)
        {
            this.ctx = ctx ?? GetInMemoryDBContext();
        }
        protected AppDBContext GetInMemoryDBContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<AppDBContext>();
            var options = builder.UseInMemoryDatabase("testDB").UseInternalServiceProvider(serviceProvider).Options;

            AppDBContext dbContext = new AppDBContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }
}
