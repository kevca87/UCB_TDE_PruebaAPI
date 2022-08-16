using Iter0_Backend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Iter0_Backend.Data
{
    public class AppDBContext : DbContext
    {
        public DbSet<KidEntity> Kids { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<KidEntity>().ToTable("Kids");
            modelBuilder.Entity<KidEntity>().Property(k => k.Id).ValueGeneratedOnAdd();
        }
    }
}
