using Microsoft.EntityFrameworkCore;

namespace WarehouseSystem.Infrastructure.Context
{
    public sealed class WareHouseDbContext(
        DbContextOptions<WareHouseDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WareHouseDbContext).Assembly);
        }
    }
}
