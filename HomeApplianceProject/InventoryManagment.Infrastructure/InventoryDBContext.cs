using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure
{
    public class InventoryDBContext : DbContext
    {
        public DbSet<Inventory> Inventory { get; set; }
        public InventoryDBContext(DbContextOptions<InventoryDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(InventoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}